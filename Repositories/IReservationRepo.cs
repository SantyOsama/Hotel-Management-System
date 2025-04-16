using HotelMangementSystem.Models;

namespace HotelMangementSystem.Repositories
{
    public interface IReservationRepo : IGeneralRepo<Reservation>
    {
        public List<Reservation> GetReservations();
        public List<Reservation> GetNotCompletedReservations();
        public Reservation GetReservationByUserAndBookingDate(string userId, DateTime BookingDate);
        public List<Reservation> GetReservationByUser(string userId);
        public Reservation GetReservationByIdWithBillNoTracking(int id);
        public Reservation GetReservationByIdWithBill(int id);
    }
}
