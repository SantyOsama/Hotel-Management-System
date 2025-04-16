using System.Threading.Tasks;
using HotelMangementSystem.Models;
using HotelMangementSystem.Repositories;
using HotelMangementSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace HotelMangementSystem.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserRepo userRepo;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IReservationRepo reservationRepo;

        public ProfileController(IUserRepo userRepo, UserManager<ApplicationUser> userManager, IReservationRepo reservationRepo)
        {
            this.userRepo = userRepo;
            this.userManager = userManager;
            this.reservationRepo = reservationRepo;
        }
        public async Task<IActionResult> Index()
        {
            var user = await userRepo.GetCurrentUserAsync(HttpContext);
            if (user != null)
            {

                ViewBag.LatestBookesHotels = reservationRepo.GetReservationByUser(user.Id);
            }
            if (user == null)
            {
                return NotFound();
            }
            return View("Index", user);

        }


        public async Task<IActionResult> Edit()
        {

            var user = await userRepo.GetCurrentUserAsync(HttpContext);
            if (user == null)
            {
                return NotFound();
            }
            var userViewModel = new ProfileViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                CurrentProfilePictureUrl = user.ProfilePictureURL,
            };

            return View("Edit", userViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProfileViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            ApplicationUser user = await userRepo.GetCurrentUserAsync(HttpContext);
            if (user == null) { return NotFound(); }
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.ProfilePictureURL = await userRepo.UpdateUserImgAsync(user, model.ProfileImage, model);
            await userManager.UpdateAsync(user);
            //await userRepo.UpdateUserAsync(user, model.ProfileImage);
            return RedirectToAction("Index");

        }


    }
}
