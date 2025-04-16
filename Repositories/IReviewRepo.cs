using HotelMangementSystem.Models;

namespace HotelMangementSystem.Repositories
{
    public interface IReviewRepo : IGeneralRepo<Review>
    {

        public void AddReview(Review review);
        public List<Review> GetReviewsByHotelId(int hotelId);

        public List<Review> getAllWithUser();
        public List<Review> getAllWithUserAndHotels();
        public List<Review> GetReviews();
        public List<Review> getSevenRandomReviewsWithUserAndHotels();
    }
}
