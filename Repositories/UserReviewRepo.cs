using HotelMangementSystem.Models;
using HotelMangementSystem.Models.Database;

namespace HotelMangementSystem.Repositories
{
    public class UserReviewRepo : GeneralRepo<UserReview>, IUserReviewRepo
    {
        private readonly DatabaseContext context;

        public UserReviewRepo(DatabaseContext context) : base(context)
        {
            this.context = context;
        }
        public List<UserReview> GetUserReviews()
        {
            return context.UserReviews.ToList();
        }
    }
}
