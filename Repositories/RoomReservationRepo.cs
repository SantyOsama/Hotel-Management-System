using HotelMangementSystem.Models;
using HotelMangementSystem.Models.Database;

namespace HotelMangementSystem.Repositories
{
    public class RoomReservationRepo : GeneralRepo<RoomReservation>, IRoomReservationRepo
    {
        private readonly DatabaseContext context;

        public RoomReservationRepo(DatabaseContext context) : base(context)
        {
            this.context = context;
        }
        public List<RoomReservation> GetRoomReservations()
        {
            return context.RoomReservations.ToList();
        }
        public RoomReservation GetRoomReservationByReservationId(int id)
        {
            return context.RoomReservations.FirstOrDefault(rr => rr.ReservationId == id);
        }
    }
}
