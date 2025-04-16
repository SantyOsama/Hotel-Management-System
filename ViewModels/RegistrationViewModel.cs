using System.ComponentModel.DataAnnotations;

namespace HotelMangementSystem.ViewModels
{
    public class RegistrationViewModel
    {
        public string UserName { get; set; }


        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }




        //public string? ProfilePictureURL { get; set; } = "/images/blank-profile-picture-973460_1280.png";






        [DataType(DataType.Upload)]
        public IFormFile? ProfilePic { get; set; }



        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


        public string PhoneNumber { get; set; }

    }
}
