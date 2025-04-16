using HotelMangementSystem.Models;
using HotelMangementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelMangementSystem.Controllers
{
    public class BookController : Controller
    {
        private readonly IRoomRepo roomRepo;

        public BookController(IRoomRepo roomRepo)
        {
            this.roomRepo = roomRepo;
        }


    }
}
