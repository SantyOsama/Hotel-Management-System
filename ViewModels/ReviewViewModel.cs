using HotelMangementSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelMangementSystem.ViewModels
{
    public class ReviewViewModel
    {
        public string UserId { get; set; }
        public int hotelId { get; set; }
        public string Content { get; set; }

        public DateTime ReviewDate { get; set; }
        public bool IsDeleted { get; set; }

        public int HotelId { get; set; }


    }
}
