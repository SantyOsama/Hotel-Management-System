using HotelMangementSystem.Models;
using HotelMangementSystem.Repositories;
using HotelMangementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using static HotelMangementSystem.Models.Enums.Enums;

namespace HotelMangementSystem.Controllers
{
    public class HotelsController : Controller
    {
        private readonly IHotelRepo hotelRepo;

        public HotelsController(IHotelRepo hotelRepo)
        {
            this.hotelRepo = hotelRepo;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string cityName, string sortOrder = "desc", int page = 1, int pageSize = 6)
        {
            var hotels = await hotelRepo.GetHotelsByCityOrderdByStartsAsync(cityName, page, pageSize, sortOrder);

            var hotelViewModels = hotels.Select(h => new HotelViewModel
            {
                Id = h.Id,
                Name = h.Name,
                Location = h.City.Name,
                PhoneNumber = h.PhoneNumber,
                Description = h.Description,
                NumberOfRooms = h.NumberOfRooms,
                StarRating = h.StarRatig
            }).ToList();



            int totalHotels = await hotelRepo.GetTotalHotelsCountAsync(cityName);
            ViewBag.Cities = await hotelRepo.GetAllCitiesAsync();
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalHotels / pageSize);
            ViewBag.CityName = cityName;
            ViewBag.SortOrder = sortOrder;

            return View(hotelViewModels);
        }

        public async Task<IActionResult> Hotel(int id)
        {
            Hotel hotel = await hotelRepo.GetHotelByIdWithAvailableRoomOnlyAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            HotelAndReviewViewModel hotelAndReviewViewModel = new HotelAndReviewViewModel()
            {
                HotelId = hotel.Id,
                HotelName = hotel.Name,
                HotelDescription = hotel.Description,
                HotelStarRatig = hotel.StarRatig,
                HotelStatus = hotel.HotelStatus,
                HotelLocation = hotel.Location,
                HotelPhoneNumber = hotel.PhoneNumber,
                HotelNumberOfRooms = hotel.NumberOfRooms,
                HotelIsDeleted = hotel.IsDeleted,
                HotelManagerId = hotel.ManagerId,
                HotelCityId = hotel.CityId,
                HotelManager = hotel.Manager,
                HotelCity = hotel.City,
                HotelRooms = hotel.Rooms,
                HotelReviews = hotel.Reviews,

            };
            return View("Hotel", hotelAndReviewViewModel);
        }

    }
}
