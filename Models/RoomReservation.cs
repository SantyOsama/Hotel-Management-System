using System.ComponentModel.DataAnnotations.Schema;

namespace HotelMangementSystem.Models
{
    public class RoomReservation
    {
        public int Id { get; set; }

        [ForeignKey("Reservation")]
        public int ReservationId { get; set; }

        public List<int> RoomId { get; set; }

        public Reservation? Reservation { get; set; }
        public List<Room>? Rooms { get; set; }
    }
}
