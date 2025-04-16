using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HotelMangementSystem.Models;
using static HotelMangementSystem.Models.Enums.Enums;

namespace HotelMangementSystem.ViewModels
{
    public class HotelAndReviewViewModel
    {
        public int HotelId { get; set; }

        public string HotelName { get; set; }
        public string HotelDescription { get; set; }
        [Range(1, 5)]
        public int HotelStarRatig { get; set; }
        public NewHotelRquestStatus HotelStatus { get; set; }

        public string HotelLocation { get; set; }
        public string HotelPhoneNumber { get; set; }
        public int HotelNumberOfRooms { get; set; }
        public bool HotelIsDeleted { get; set; }

        [ForeignKey("Manager")]
        public string HotelManagerId { get; set; }


        [ForeignKey("City")]

        public int HotelCityId { get; set; }


        public ApplicationUser? HotelManager { get; set; }
        public City? HotelCity { get; set; }
        public List<Room>? HotelRooms { get; set; }
        public List<Review>? HotelReviews { get; set; }
        /*-----------------------------------------------------------------------------------*/
        public int ReviewStarNumber { get; set; }
        public string ReviewContent { get; set; }
        public string ReviewUserName { get; set; }
        public DateTime ReviewDate { get; set; }

        [ForeignKey("Hotel")]
        public bool ReviewIsDeleted { get; set; }
        public int ReviewHotelId { get; set; }

        public Hotel? ReviewHotel { get; set; }
        public ApplicationUser? ReviewUser { get; set; }
        public UserReview? ReviewUserReview { get; set; }
    }
}
