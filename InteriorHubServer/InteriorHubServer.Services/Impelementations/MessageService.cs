using InteriorHubServer.Domain.Contracts;
using InteriorHubServer.Domain.Entities;
using InteriorHubServer.Domain.Interfaces.Repositories;
using InteriorHubServer.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace InteriorHubServer.Services.Impelementations
{
    public class MessageService : BaseEntityService<Message>, IMessageService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MessageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<MessageDto> CreateMessageAsync(MessageCreateRequest request)
        {
            var sender = _unitOfWork.UserRepository.FindByCondition(u => u.Id == request.SenderId, true).FirstOrDefault();
            var recipient = _unitOfWork.UserRepository.FindByCondition(u => u.Id == request.RecipientId, true).FirstOrDefault();
            if (sender == null || recipient == null)
            {
                throw new Exception("user not exist");
            }
            var dialog = _unitOfWork.DialogRepository.FindByCondition(d => d.Users.Contains(sender) && d.Users.Contains(recipient), true).FirstOrDefault();
            var message = new Message
            {
                Sender = sender,
                //SenderId = request.SenderId,
                Text = request.Text,
            };
            if (dialog == null)
            {
                dialog = new Dialog();
                dialog.Users.Add(sender);
                dialog.Users.Add(recipient);
            }
            message.Dialog = dialog;

            _unitOfWork.MessageRepository.Create(message);
            var success = await _unitOfWork.SaveAsync();
            if(success)
            {
                return new MessageDto
                {
                    Id = message.Id,
                    Text = message.Text,
                    Date = message.CreatedOn,
                    IsCurrentUser = true,
                    IsViewed = message.IsViewed
                };
            }
            return null;
        }
        public async Task<IEnumerable<GetDialogsResponse>> GetDialogsAsync(User user)
        {
            var dialogsQ = _unitOfWork.DialogRepository.FindByCondition(d => d.Users.Contains(user), true);
            //var dialogsQ = _unitOfWork.UserRepository.FindByCondition(u => u == user, true);
            AddIncludeToCollection(ref dialogsQ);
            var dialogs = await dialogsQ.ToListAsync();
            return dialogs.Select(d =>
            {
                var dialogUser = d.Users.FirstOrDefault(x => x != user);
                return new GetDialogsResponse
                {
                    Id = d.Id,
                    LastMessage = d.Messages.OrderByDescending(m => m.CreatedOn).Take(1).Select(m => new MessageDto
                    {
                        Id = m.Id,
                        DialogId = d.Id,
                        Text = m.Text,
                        Date = m.CreatedOn,
                        IsCurrentUser = m.Sender.Id == user.Id,
                        IsViewed = m.IsViewed
                    }).FirstOrDefault(),
                    Contact = new GetDialogsResponse.DialogContact
                    {
                        Id = dialogUser.Id,
                        AvatarImgUrl = dialogUser.Photo?.Url,
                        Name = dialogUser.Agency != null ? dialogUser.Agency.Name :
                        (string.IsNullOrEmpty(dialogUser.Name) ?
                        "user0000" + dialogUser.Id : (string.IsNullOrEmpty(dialogUser.Lastname) ?
                        dialogUser.Name : dialogUser.Name + " " + dialogUser.Lastname)),
                    },
                    UnviewedCount = d.Messages.Where(m => !m.IsViewed && m.SenderId != user.Id).Count()
                };
            });
        }

        public async Task<int> GetUnreadAsync(User user)
        {
            var dialogsQ = _unitOfWork.DialogRepository.FindByCondition(d => d.Users.Contains(user), true);
            //var dialogsQ = _unitOfWork.UserRepository.FindByCondition(u => u == user, true);
            AddIncludeToCollection(ref dialogsQ);
            var dialogs = await dialogsQ.ToListAsync();
            var unreadCount = 0;
            dialogs.ForEach(d =>
            {
                unreadCount += d.Messages.Where(m => !m.IsViewed && m.SenderId != user.Id).Count();
            });
            return unreadCount;
        }

        public async Task<IEnumerable<MessageDto>> GetMessagesByDialogIdsAsync(long dialogId, User user)
        {
            var messagesQ = _unitOfWork.MessageRepository.FindByCondition(m => m.DialogId == dialogId, true);
            //AddIncludeToCollection(ref messagesQ);
            var messages = await messagesQ.ToListAsync();
            messages.ForEach(m =>
            {
                if(m.SenderId != user.Id)
                {
                    m.IsViewed = true;
                }
            });
            await _unitOfWork.SaveAsync();
            return messages.Select(m => new MessageDto
            {
                Id = m.Id,
                DialogId = dialogId,
                Text = m.Text,
                Date = m.CreatedOn,
                IsCurrentUser = m.SenderId == user.Id,
                IsViewed = m.IsViewed
            });
        }
        
        private void AddIncludeToCollection(ref IQueryable<Dialog> dialogs)
        {
            dialogs = dialogs
                .Include(d => d.Users).ThenInclude(u => u.Photo)
                .Include(d => d.Users).ThenInclude(u => u.Agency)
                .Include(d => d.Messages);
        }

        private void AddIncludeToCollection(ref IQueryable<Message> messages)
        {
            //messages = messages.Include(m => m.SenderId);
        }
    }
}