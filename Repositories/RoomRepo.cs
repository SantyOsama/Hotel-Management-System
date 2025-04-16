using HotelMangementSystem.Models;
using HotelMangementSystem.Models.Database;
using HotelMangementSystem.Models.Enums;
using Microsoft.EntityFrameworkCore;
using static HotelMangementSystem.Models.Enums.Enums;
using HotelMangementSystem.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace HotelMangementSystem.Repositories
{
    public class RoomRepo : GeneralRepo<Room>, IRoomRepo
    {
        private readonly DatabaseContext context;
        private readonly IRoomReservationRepo roomReservationRepo;

        public RoomRepo(DatabaseContext context, IRoomReservationRepo roomReservationRepo) : base(context)
        {
            this.context = context;
            this.roomReservationRepo = roomReservationRepo;
        }
        public List<Room> GetRooms()
        {
            return context.Rooms.Where(b => b.IsDeleted == false).ToList();
        }
        public async Task<List<Room>> SearchRoomsAsync(int cityId, RoomTypes roomType)
        {
            try
            {
                return await context.Rooms
                    .AsNoTracking()
                    .Include(r => r.Hotel)
                    .ThenInclude(h => h.City)
                    .Where(r => !r.IsDeleted &&
                                r.RoomType == roomType &&
                                r.Hotel.CityId == cityId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching rooms: {ex.Message}");
                return new List<Room>();
            }
        }
        public async Task<List<Room>> SearchAvailableRoomsOnlyAsync(int cityId, RoomTypes roomType)
        {
            try
            {
                return await context.Rooms
                    .AsNoTracking()
                    .Include(r => r.Hotel)
                    .ThenInclude(h => h.City)
                    .Where(r => !r.IsDeleted &&
                                r.RoomType == roomType &&
                                r.Hotel.CityId == cityId &&
                                r.roomStatus == RoomStatuses.Available)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching rooms: {ex.Message}");
                return new List<Room>();
            }
        }
        public Room GetById(int id)
        {
            var room = context.Rooms.AsNoTracking().Include(r => r.Hotel).AsNoTracking().FirstOrDefault(r => r.Id == id);
            if (room != null && room.Hotel != null)
            {
                context.Entry(room.Hotel).State = EntityState.Detached;
            }
            return room;
        }
        public void SoftDelete(Room room)
        {
            room.IsDeleted = true;
            room.roomStatus = Enums.RoomStatuses.NotAvailable;
        }


        public Room GetByIdWithNoTracking(int id)
        {
            var room = context.Rooms.AsNoTracking().Include(r => r.RoomReservation).Include(r => r.Hotel).AsNoTracking().FirstOrDefault(r => r.Id == id);
            if (room != null && room.Hotel != null)
            {
                context.Entry(room.Hotel).State = EntityState.Detached;
            }
            return room;

        }

        public void UpdateRoomStatues(int id, RoomReservation roomReservation)
        {
            Room room = GetByIdWithNoTracking(id);
            room.roomStatus = RoomStatuses.NotAvailable;
            room.RoomReservation = roomReservation;
            room.RoomReservation.Id = roomReservation.Id;
            if (room.Hotel != null)
            {
                context.Entry(room.Hotel).State = EntityState.Detached;
            }
            context.Entry(room).State = EntityState.Modified;

            context.Rooms.Update(room);
        }


        public void UpdateRoomStatuesAvailable(int id)
        {
            Room room = GetByIdWithNoTracking(id);
            room.roomStatus = RoomStatuses.Available;
            room.RoomReservation.Id = 0;
            room.RoomReservation = null;
            if (room.Hotel != null)
            {
                context.Entry(room.Hotel).State = EntityState.Detached;
            }
            context.Entry(room).State = EntityState.Modified;

            context.Rooms.Update(room);
        }

        public void UpdateReservationRoom(int id, RoomReservation roomReservation)
        {
            Room room = GetByIdWithNoTracking(id);
            room.RoomReservation = roomReservation;
            context.Entry(room).State = EntityState.Modified;
            room.RoomReservation.Id = roomReservation.Id;
            context.Rooms.Update(room);

        }

    }
}
