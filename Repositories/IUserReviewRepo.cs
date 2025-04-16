using HotelMangementSystem.Models;

namespace HotelMangementSystem.Repositories
{
    public interface IUserReviewRepo : IGeneralRepo<UserReview>
    {
        public List<UserReview> GetUserReviews();
    }
}
