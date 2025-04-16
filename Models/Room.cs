using System.ComponentModel.DataAnnotations.Schema;
using static HotelMangementSystem.Models.Enums.Enums;

namespace HotelMangementSystem.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public RoomTypes RoomType { get; set; }
        public string Description { get; set; }
        public int PricePerNight { get; set; }
        public int Capacity { get; set; }
        public RoomStatuses roomStatus { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("Hotel")]
        public int HotelId { get; set; }


        public Hotel? Hotel { get; set; }
        public Reservation? Reservation { get; set; }

        public RoomReservation? RoomReservation { get; set; }
    }
}
