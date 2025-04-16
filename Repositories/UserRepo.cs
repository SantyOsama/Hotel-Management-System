using HotelMangementSystem.Models;
using HotelMangementSystem.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.IO;
using System.Security.Claims;

namespace HotelMangementSystem.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment environment;
        private readonly IFileRepo fileRepo;

        public UserRepo(UserManager<ApplicationUser> userManager, IWebHostEnvironment environment, IFileRepo fileRepo)
        {
            this.userManager = userManager;
            this.environment = environment;
            this.fileRepo = fileRepo;
        }

        public async Task<ApplicationUser?> GetCurrentUserAsync(HttpContext httpContext)
        {

            return await userManager.GetUserAsync(httpContext.User);

        }

        public async Task<string> UpdateUserImgAsync(ApplicationUser user, IFormFile? profileImage, ProfileViewModel model)
        {
            var path = "";
            if (profileImage?.Length > 0)
            {
                path = await fileRepo.Upload(model.ProfileImage, "/images/profilePictures/", user.UserName);

            }
            return path;

        }
    }
}
