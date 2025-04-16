using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace HotelMangementSystem.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string? ProfilePictureURL { get; set; } = "/images/blank-profile-picture-973460_1280.png";




        [NotMapped]

        public IFormFile? ProfilePic { get; set; }


        public List<Review>? Reviews { get; set; }
        public List<Hotel>? Hotel { get; set; }
        public List<Reservation>? Reservations { get; set; }
        public UserReview? UserReview { get; set; }



    }
}
