using System.Linq;
using HotelMangementSystem.Models;
using HotelMangementSystem.Models.Database;
using Microsoft.EntityFrameworkCore;
using static HotelMangementSystem.Models.Enums.Enums;

namespace HotelMangementSystem.Repositories
{
    public class ReservationRepo : GeneralRepo<Reservation>, IReservationRepo
    {
        private readonly DatabaseContext context;

        public ReservationRepo(DatabaseContext context) : base(context)
        {
            this.context = context;
        }
        public List<Reservation> GetReservations()
        {
            return context.Reservations.Where(b => b.IsDeleted == false).ToList();
        }
        public List<Reservation> GetNotCompletedReservations()
        {
            return context.Reservations.Where(b => b.IsDeleted == false && b.ReservistionStatus == ReservistionStatuses.Confirmed).ToList();
        }

        public Reservation GetReservationByUserAndBookingDate(string userId, DateTime BookingDate)
        {
            return context.Reservations.FirstOrDefault(r => r.UserId.Contains(userId) && r.BookingDate == BookingDate);
        }
        public List<Reservation> GetReservationByUser(string userId)
        {
            return context.Reservations.AsNoTracking().Include(R => R.Bill).AsNoTracking().Where(r => r.UserId.Contains(userId)).ToList();

        }
        public Reservation GetReservationByIdWithBillNoTracking(int id)
        {
            return context.Reservations.AsNoTracking().Include(R => R.Bill).AsNoTracking().FirstOrDefault(r => r.Id == id);

        }
        public Reservation GetReservationByIdWithBill(int id)
        {
            return context.Reservations.Include(R => R.Bill).FirstOrDefault(r => r.Id == id);

        }
    }
}
