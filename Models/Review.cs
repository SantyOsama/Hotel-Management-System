using System.ComponentModel.DataAnnotations.Schema;

namespace HotelMangementSystem.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int StarNumber { get; set; }
        public string Content { get; set; }
        public DateTime ReviewDate { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("Hotel")]
        public int HotelId { get; set; }

        public Hotel? Hotel { get; set; }
        public ApplicationUser? User { get; set; }
        public UserReview? UserReview { get; set; }
    }
}
