using System.ComponentModel.DataAnnotations;
using System.Configuration;
using static HotelMangementSystem.Models.Enums.Enums;

namespace HotelMangementSystem.ViewModels
{

    public class RoomViewModel
    {
        public int Id { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Room number must be greater than 1")]
        public int RoomNumber { get; set; }
        public RoomTypes RoomType { get; set; }
        public string Description { get; set; }


        [Range(1, 10)]
        public int Capacity { get; set; }




        [Range(150, int.MaxValue, ErrorMessage = "Price must be greater than 150$")]
        public int PricePerNight { get; set; }
        public int HotelId { get; set; }
        public RoomStatuses roomStatus { get; set; } = RoomStatuses.Available;

    }


}
