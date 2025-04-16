using static HotelMangementSystem.Models.Enums.Enums;

namespace HotelMangementSystem.Models
{


    public class Bill
    {
        public int Id { get; set; }
        public int RoomCharge { get; set; }
        public bool LateCheckout { get; set; }
        public DateTime CheckoutDate { get; set; }
        public PaymentMethods PaymentMethod { get; set; }
        public int TotalPrice { get; set; }
        public ReservistionStatuses ReservistionStatus { get; set; }
        public bool IsDeleted { get; set; }


        public Reservation? Reservation { get; set; }

    }
}
