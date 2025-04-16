using HotelMangementSystem.Models;

namespace HotelMangementSystem.ViewModels
{
    public class RolesAndUsersViewModel
    {
        public List<ApplicationUser> Users { get; set; }
        public List<ApplicationRole> Roles { get; set; }
    }
}
