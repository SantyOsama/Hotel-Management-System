using HotelMangementSystem.Models;
using HotelMangementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static HotelMangementSystem.Models.Enums.Enums;

namespace HotelMangementSystem.Controllers
{
    public class RoomsController : Controller
    {
        private IRoomRepo roomRepo;
        private ICityRepo cityRepo;

        public RoomsController(IRoomRepo roomRepo, ICityRepo cityRepo)
        {
            this.roomRepo = roomRepo;
            this.cityRepo = cityRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchRooms(int cityId, RoomTypes roomType)
        {
            var rooms = await roomRepo.SearchAvailableRoomsOnlyAsync(cityId, roomType);
            List<City> cities = cityRepo.GetCities();
            ViewBag.cities = cities;
            return View("RoomList", rooms);
        }




        public IActionResult Room(int id)
        {
            Room room = roomRepo.GetById(id);

            return View(room);
        }

    }
}
