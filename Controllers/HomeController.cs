using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HotelMangementSystem.Models;
using HotelMangementSystem.Repositories;
using HotelMangementSystem.Hubs;
using Microsoft.AspNetCore.SignalR;
using static HotelMangementSystem.Models.Enums.Enums;
using Microsoft.AspNetCore.Identity;

namespace HotelMangementSystem.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHotelRepo hotelRepo;
    private readonly IReviewRepo reviewRepo;
    private readonly IPendingHotelRepo pendingHotelRepo;
    private readonly IHubContext<HAddHotelHub> addHotelHub;
    private readonly IRoomRepo roomRepo;
    private readonly IReservationRepo reservationRepo;
    private readonly IRoomReservationRepo roomReservationRepo;
    private readonly IBillRepo billRepo;
    private readonly ICityRepo cityRepo;

    public HomeController(ILogger<HomeController> logger, IHotelRepo hotelRepo, IReviewRepo reviewRepo, IPendingHotelRepo pendingHotelRepo, ICityRepo cityRepo, IHubContext<HAddHotelHub> addHotelHub, IRoomRepo roomRepo, IReservationRepo reservationRepo, IRoomReservationRepo roomReservationRepo, IBillRepo billRepo)
    {
        _logger = logger;
        this.hotelRepo = hotelRepo;
        this.reviewRepo = reviewRepo;
        this.pendingHotelRepo = pendingHotelRepo;
        this.addHotelHub = addHotelHub;
        this.roomRepo = roomRepo;
        this.reservationRepo = reservationRepo;
        this.roomReservationRepo = roomReservationRepo;
        this.billRepo = billRepo;
        this.cityRepo = cityRepo;
    }

    public IActionResult Index()
    {
        List<Hotel> hotels = hotelRepo.GetFourTopRatedRandomizedHotels();
        ViewBag.hotels = hotels;
        List<Review> reviews = reviewRepo.getSevenRandomReviewsWithUserAndHotels();
        ViewBag.reviews = reviews;
        List<City> cities = cityRepo.GetCities();
        ViewBag.cities = cities;

        ViewBag.PendingHotelNumberNotification = pendingHotelRepo.GetPendingHotels().Count();
        CheckReservationEnd();
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public void CheckReservationEnd()
    {
        List<Reservation> Reservations = reservationRepo.GetNotCompletedReservations();



        foreach (Reservation reservation in Reservations)
        {
            if (reservation.CheckOutDate.Date == DateTime.Now.Date)
            {
                reservation.ReservistionStatus = ReservistionStatuses.Completed;
                reservation.Bill.ReservistionStatus = ReservistionStatuses.Completed;
                RoomReservation roomReservation = roomReservationRepo.GetRoomReservationByReservationId(reservation.Id);
                List<int> rooms = roomReservation.RoomId;
                foreach (int roomId in rooms)
                {
                    Room room = roomRepo.GetByIdWithNoTracking(roomId);
                    room.roomStatus = RoomStatuses.Available;
                    room.RoomReservation.Id = 0;
                    room.RoomReservation = null;
                }

            }
        }
    }
}
