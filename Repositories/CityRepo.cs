using HotelMangementSystem.Models;
using HotelMangementSystem.Models.Database;

namespace HotelMangementSystem.Repositories
{
    public class CityRepo : GeneralRepo<City>, ICityRepo
    {
        private readonly DatabaseContext context;

        public CityRepo(DatabaseContext context) : base(context)
        {
            this.context = context;
        }
        public List<City> GetCities()
        {
            return context.Cities.Where(b => b.IsDeleted == false).ToList();
        }
    }
}
