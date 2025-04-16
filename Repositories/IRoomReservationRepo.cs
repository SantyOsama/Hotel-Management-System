using HotelMangementSystem.Models;

namespace HotelMangementSystem.Repositories
{
    public interface IRoomReservationRepo : IGeneralRepo<RoomReservation>
    {
        public List<RoomReservation> GetRoomReservations();
        public RoomReservation GetRoomReservationByReservationId(int id);
    }
}
