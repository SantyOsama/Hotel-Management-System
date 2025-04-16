using HotelMangementSystem.Models;
using Microsoft.Data.SqlClient;

namespace HotelMangementSystem.Repositories
{
    public interface IHotelRepo : IGeneralRepo<Hotel>
    {
        public List<Hotel> GetHotels();
        public List<Hotel> GetHotelsByManagerId(string id);

        Task<List<Hotel>> GetHotelsByCityAsync(string cityName, int page, int pageSize);
        Task<int> GetTotalHotelsCountAsync(string cityName);
        Task<List<string>> GetAllCitiesAsync();
        Task<Hotel> GetHotelByIdAsync(int id);
        List<Hotel> GetFourTopRatedRandomizedHotels();
        Task<Room> GetRoomByIdAsync(int id);
        Task DeleteRoom(Room room, int HotelId);
        Task<Hotel> GetHotelWithRoomsAsync(int id);
        Task<List<Hotel>> GetHotelsByCityOrderdByStartsAsync(string cityName, int page, int pageSize, string sortOrder = "desc");
        Task<Hotel> GetHotelByIdWithAvailableRoomOnlyAsync(int id);
    }
}
