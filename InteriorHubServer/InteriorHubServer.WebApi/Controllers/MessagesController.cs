using InteriorHubServer.Domain.Contracts;
using InteriorHubServer.Domain.Entities;
using InteriorHubServer.Domain.Wrappers;
using InteriorHubServer.Services.Abstractions;
using InteriorHubServer.Services.Impelementations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Security.Claims;

namespace InteriorHubServer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IHubContext<MessageHub> _hub;
        private readonly IMessageService _messageService;
        private readonly IAuthService _authService;
        public MessagesController(IHubContext<MessageHub> hub, IMessageService messageService, IAuthService authService)
        {
            _hub = hub;
            _messageService = messageService;
            _authService = authService;
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User,Pro")]
        public async Task<IActionResult> Post([FromBody] MessageCreateRequest request)
        {
            User user = await _authService.GetUserByName(User.Identity.Name);
            if (user == null)
                return Unauthorized(); // user not exist
            request.SenderId = user.Id;
            var result = await _messageService.CreateMessageAsync(request);
            var recipient = await _authService.GetUserById(request.RecipientId);
            var recipientConnections = MessageHub.GetUserConnections(recipient.UserName);
            if(recipientConnections != null)
            {
                await _hub.Clients.Clients(recipientConnections).SendAsync("SendMessage", result);
            }
            return Ok(result);
        }
        [Route("dialogs")]
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetDialogs()
        {
            User user = null;
            if (User.Identity!.IsAuthenticated)
            {
                user = await _authService.GetUserByName(User.Identity.Name);
                var dialogs = await _messageService.GetDialogsAsync(user);
                var response = new Response<IEnumerable<GetDialogsResponse>>(dialogs);
                return Ok(response);
            }
            return Unauthorized();
        }
        [Route("unread")]
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetUnread()
        {
            User user = null;
            if (User.Identity!.IsAuthenticated)
            {
                user = await _authService.GetUserByName(User.Identity.Name);
                var unreadCount = await _messageService.GetUnreadAsync(user);
                var response = new Response<int>(unreadCount);
                return Ok(response);
            }
            return Unauthorized();
        }
        [HttpGet("{dialogId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Get(long dialogId)
        {
            if (User.Identity!.IsAuthenticated)
            {
                User user = await _authService.GetUserByName(User.Identity.Name);
                var messages = await _messageService.GetMessagesByDialogIdsAsync(dialogId, user);
                var response = new Response<IEnumerable<MessageDto>>(messages);
                return Ok(response);
            }
            return Unauthorized();
        }
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[Authorize]
    public class MessageHub: Hub
    {
        public static ConcurrentDictionary<string, List<string>> ConnectedUsers = new ConcurrentDictionary<string, List<string>>();

        public override Task OnConnectedAsync()
        {
            Trace.TraceInformation("MapHub started. ID: {0}", Context.ConnectionId);
            var userName = Context.User.Identity.Name;
            List<string> existingUserConnectionIds;
            ConnectedUsers.TryGetValue(userName, out existingUserConnectionIds);
            if (existingUserConnectionIds == null)
            {
                existingUserConnectionIds = new List<string>();
            }
            existingUserConnectionIds.Add(Context.ConnectionId);
            ConnectedUsers.TryAdd(userName, existingUserConnectionIds);
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            var userName = Context.User.Identity.Name;
            List<string> existingUserConnectionIds;
            ConnectedUsers.TryGetValue(userName, out existingUserConnectionIds);
            existingUserConnectionIds.Remove(Context.ConnectionId);
            if (existingUserConnectionIds.Count == 0)
            {
                List<string> garbage; // to be collected by the Garbage Collector
                ConnectedUsers.TryRemove(userName, out garbage);
            }
            return base.OnDisconnectedAsync(exception);
        }

        public static List<string> GetUserConnections(string userName)
        {
            List<string> existingUserConnectionIds;
            ConnectedUsers.TryGetValue(userName, out existingUserConnectionIds);
            return existingUserConnectionIds;
        }
    }
}