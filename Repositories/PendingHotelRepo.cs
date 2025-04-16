using HotelMangementSystem.Models;
using HotelMangementSystem.Models.Database;
using static HotelMangementSystem.Models.Enums.Enums;

namespace HotelMangementSystem.Repositories
{
    public class PendingHotelRepo : GeneralRepo<PendingHotel>, IPendingHotelRepo
    {
        private readonly DatabaseContext context;

        public PendingHotelRepo(DatabaseContext context) : base(context)
        {
            this.context = context;
        }
        public PendingHotel CheckIfExists(string HotelName, string ManagerID)
        {
            PendingHotel hotel = context.PendingHotels.FirstOrDefault(h => h.Name.Contains(HotelName) && h.ManagerId.Contains(ManagerID) && h.IsDeleted == false);
            return hotel;
        }
        public PendingHotel GetRequestByManagerID(string ManagerID)
        {
            PendingHotel hotel = context.PendingHotels.FirstOrDefault(h => h.ManagerId.Contains(ManagerID) && h.IsDeleted == false);
            return hotel;
        }
        public List<PendingHotel> GetPendingHotels()
        {
            return context.PendingHotels.Where(b => b.IsDeleted == false).ToList();
        }
        public List<PendingHotel> GetDeniedHotels()
        {
            return context.PendingHotels.Where(b => b.IsDeleted == true && b.HotelStatus == NewHotelRquestStatus.Denied).ToList();

        }
    }
}
