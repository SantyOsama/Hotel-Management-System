using HotelMangementSystem.Models;
using static HotelMangementSystem.Models.Enums.Enums;

namespace HotelMangementSystem.Repositories
{
    public interface IRoomRepo : IGeneralRepo<Room>
    {
        public List<Room> GetRooms();
        public void SoftDelete(Room room);

        Task<List<Room>> SearchRoomsAsync(int cityId, RoomTypes roomType);
        Task<List<Room>> SearchAvailableRoomsOnlyAsync(int cityId, RoomTypes roomType);
        public Room GetByIdWithNoTracking(int id);
        public void UpdateRoomStatues(int id, RoomReservation roomReservation);
        public void UpdateRoomStatuesAvailable(int id);
        public void UpdateReservationRoom(int id, RoomReservation roomReservation);
    }
}
