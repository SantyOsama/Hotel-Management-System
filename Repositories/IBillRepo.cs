using HotelMangementSystem.Models;

namespace HotelMangementSystem.Repositories
{
    public interface IBillRepo : IGeneralRepo<Bill>
    {
        public List<Bill> GetBills();
    }
}
