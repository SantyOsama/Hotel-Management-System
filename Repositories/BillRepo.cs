using HotelMangementSystem.Models;
using HotelMangementSystem.Models.Database;

namespace HotelMangementSystem.Repositories
{
    public class BillRepo : GeneralRepo<Bill>, IBillRepo
    {
        private readonly DatabaseContext context;

        public BillRepo(DatabaseContext context) : base(context)
        {
            this.context = context;
        }
        public List<Bill> GetBills()
        {
            return context.Bills.Where(b => b.IsDeleted == false).ToList();
        }


    }
}
