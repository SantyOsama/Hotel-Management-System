using Microsoft.AspNetCore.Mvc;
using HotelMangementSystem.Models;

namespace HotelMangementSystem.Controllers
{
    public class HotelController : Controller
    {
        public IActionResult Index()
        {
            City city = new City { Country = "Egypt", Name = "Assiut", Id = 1, IsDeleted = false };
            Hotel hotel = new Hotel {
                Name = "Celopatra", StarRatig = 5, City = city, Description = "Whatever", IsDeleted = false, Id = 1, Location = "Assiut", CityId = 1
            , PhoneNumber = "01010144385", NumberOfRooms = 300,
            };
            
         return View("Index",hotel);
        }
    }
}
