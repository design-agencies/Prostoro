using InteriorHubServer.Domain.Contracts;
using InteriorHubServer.Domain.Entities;
using InteriorHubServer.Domain.Interfaces.Repositories;
using InteriorHubServer.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace InteriorHubServer.Services.Impelementations
{
    public class ReviewService : BaseEntityService<Review>, IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReviewService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ReviewDto> CreateAsync(CreateReviewRequest reviewRequest, User user)
        {
            if (user == null)
            {
                throw new Exception("Unauthorized");
            }
            var review = new Review
            {
                AgencyId = reviewRequest.AgencyId,
                User = user,
                UserName = user.UserName,
                Message = reviewRequest.Message,
                Rate = reviewRequest.Rate
            };
            _unitOfWork.ReviewRepository.Create(review);
            var success = await _unitOfWork.SaveAsync();
            if(success)
            {
                return new ReviewDto
                {
                    Id = review.Id,
                    UserName = review.UserName,
                    UserId = review.UserId,
                    Message = review.Message,
                    Rate = review.Rate,
                    CreatedOn = review.CreatedOn
                };
            }
            throw new Exception();
        }

        public async Task<bool> CreateComplaintAsync(CreateComplaintRequest request, User user)
        {
            if (user == null)
            {
                throw new Exception("Unauthorized");
            }
            var reviewQ = _unitOfWork.ReviewRepository.FindByCondition(a => a.Id.Equals(request.ReviewId), true).Include(r => r.Complaints);
            var review = await reviewQ.FirstOrDefaultAsync();
            var complaint = new Complaint
            {
                UserId = user.Id,
                ComplaintReason = request.ComplaintReason,
                Message = request.Message
            };
            review.Complaints.Add(complaint);
            return await _unitOfWork.SaveAsync();
        }

        public Task<bool> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(AgencyUpdateRequest entity)
        {
            throw new NotImplementedException();
        }
    }
}
