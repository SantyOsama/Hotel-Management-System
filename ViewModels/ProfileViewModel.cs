using System.ComponentModel.DataAnnotations;

namespace HotelMangementSystem.ViewModels
{
    public class ProfileViewModel
    {

        [Required]
        public string? UserName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }
        [Required]
        public IFormFile? ProfileImage { get; set; }
        public string? CurrentProfilePictureUrl { get; set; }
    }
}
