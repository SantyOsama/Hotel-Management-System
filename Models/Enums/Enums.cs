namespace HotelMangementSystem.Models.Enums
{
    public class Enums
    {
        public enum PaymentMethods
        {
            Cash = 1,
            Visa = 2,
            InstaPay = 4,
            CashApp = 8
        }
        public enum ReservistionStatuses
        {
            Cancled = 1,
            Confirmed = 2,
            Completed = 4
        }
        public enum RoomTypes
        {
            Single = 1,
            Double = 2,
            Suite = 4,
            Family = 8
        }
        public enum RoomStatuses
        {
            Available = 1,
            NotAvailable = 2

        }
        public enum NewHotelRquestStatus
        {
            Pending = 1,
            Accepted = 2,
            Denied = 4,
        }


    }
}
