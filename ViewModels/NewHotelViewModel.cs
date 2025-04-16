using HotelMangementSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelMangementSystem.ViewModels
{
    public class NewHotelViewModel
    {
        /*
 ('Hotel Cleopatra', 'Luxury accommodation in Cairo.', 5, 'Downtown', '0123456789', 200, 0, '23d3edcb-12e1-4ebb-bac9-6e12375cd266', 1),
 */

        public string Name { get; set; }
        public string Description { get; set; }
        [Range(1, 5)]
        public int StarRatig { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public int NumberOfRooms { get; set; }
        public bool IsDeleted { get; set; } = false;

        public string ManagerId { get; set; }


        public int CityId { get; set; }

        public ApplicationUser? Manager { get; set; }
        public City? City { get; set; }
        public List<Room>? Rooms { get; set; }

    }
}
