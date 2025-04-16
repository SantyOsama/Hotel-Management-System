using System.ComponentModel.DataAnnotations.Schema;

namespace HotelMangementSystem.Models
{
    public class UserReview
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }



        public Review? Review { get; set; }
        public ApplicationUser? User { get; set; }

    }
}
