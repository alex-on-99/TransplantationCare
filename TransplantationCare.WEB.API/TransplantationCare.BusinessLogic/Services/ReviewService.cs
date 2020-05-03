using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TransplantationCare.Core.Interfaces.Repositories;
using TransplantationCare.Core.Interfaces.Services;
using TransplantationCare.Core.Models.Business;
using TransplantationCare.Core.Models.DataBase;

namespace TransplantationCare.BusinessLogic.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository reviewRepository;
        private readonly IUserRepository userRepository;

        public ReviewService(IReviewRepository reviewRepository, IUserRepository userRepository)
        {
            this.reviewRepository = reviewRepository;
            this.userRepository = userRepository;
        }
        public async Task CreateReview(ReviewCreationModel reviewModel)
        {
            
            var reviewer = await userRepository.GetByLogin(reviewModel.ReviewerLogin);

            var review = new Review
            {
                Message = reviewModel.Message,
                DateTimeReview = reviewModel.DateTimeReview,
                UserId = reviewModel.UserId,
                ReviewerId = reviewer.Id
            };

            await reviewRepository.AddAsync(review);
        }
    }
}
