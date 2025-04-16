using HotelMangementSystem.Models;
using HotelMangementSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace HotelMangementSystem.Repositories
{
    public interface IUserRepo
    {
        Task<ApplicationUser?> GetCurrentUserAsync(HttpContext httpContext);
        Task<string> UpdateUserImgAsync(ApplicationUser user, IFormFile? profileImage, ProfileViewModel model);
    }
}
