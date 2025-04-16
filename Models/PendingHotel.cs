using System.ComponentModel.DataAnnotations;
using static HotelMangementSystem.Models.Enums.Enums;

namespace HotelMangementSystem.Models
{
    public class PendingHotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(1, 5)]
        public int StarRatig { get; set; }
        public NewHotelRquestStatus HotelStatus { get; set; }

        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public int NumberOfRooms { get; set; }
        public bool IsDeleted { get; set; } = false;

        public string ManagerId { get; set; }


        public int CityId { get; set; }

        public ApplicationUser? Manager { get; set; }
        public City? City { get; set; }
    }
}
