using HotelMangementSystem.Models;

namespace HotelMangementSystem.Repositories
{
    public interface ICityRepo : IGeneralRepo<City>
    {
        public List<City> GetCities();
    }
}
