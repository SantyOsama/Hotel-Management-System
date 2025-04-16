using System.Collections.Generic;
using System.Linq;
using HotelMangementSystem.Models;
using HotelMangementSystem.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace HotelMangementSystem.Repositories
{
    public class ReviewRepo : GeneralRepo<Review>, IReviewRepo
    {
        private readonly DatabaseContext context;

        public ReviewRepo(DatabaseContext context) : base(context)
        {
            this.context = context;
        }

        public void AddReview(Review review) {
             context.Reviews.Add(review);
        }
        public List<Review> GetReviewsByHotelId(int hotelId) {

            return context.Reviews
                .Where(r => r.HotelId == hotelId)
                .OrderBy(r => r.ReviewDate)
                .ToList();
        }
        public List<Review> getAllWithUser()
        {
            return context.Reviews.Include("User").Where(r => r.IsDeleted == false).ToList();

        }
        public List<Review> getAllWithUserAndHotels()
        {
            List<Review> reviews = context.Reviews.Include("User").Include("Hotel").Where(r => r.IsDeleted == false).ToList();

            return reviews;
        }
        public List<Review> GetReviews()
        {
            return context.Reviews.Where(b => b.IsDeleted == false).ToList();
        }
        public List<Review> getSevenRandomReviewsWithUserAndHotels()
        {
            List<Review> reviews = context.Reviews.Include("User").Include("Hotel").Where(r => r.IsDeleted == false).OrderBy(h => Guid.NewGuid()).Take(7).ToList();


            return reviews;

        }


    }
}
