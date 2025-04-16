using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using HotelMangementSystem.Models;
using HotelMangementSystem.Repositories;
using HotelMangementSystem.Hubs;
using HotelMangementSystem.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace HotelMangementSystem.Controllers
{
    [Authorize]
    public class ReviewController : Controller
    {
        private readonly IReviewRepo reviewRepo;
        private readonly IHotelRepo hotelRepo;
        private readonly IHubContext<HReviewHub> hubContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserReviewRepo userReviewRepo;

        public ReviewController(IReviewRepo reviewRepo, IHotelRepo hotelRepo, IHubContext<HReviewHub> hubContext, UserManager<ApplicationUser> userManager, IUserReviewRepo userReviewRepo)
        {
            this.reviewRepo = reviewRepo;
            this.hotelRepo = hotelRepo;
            this.hubContext = hubContext;
            this.userManager = userManager;
            this.userReviewRepo = userReviewRepo;
        }

        //public async Task<IActionResult> AddReview(int hotelId) {

        //    Hotel hotel = await hotelRepo.GetHotelByIdAsync(hotelId);
        //    ReviewViewModel reviewViewModel = new ReviewViewModel { hotelId = hotelId };
        //    return View("AddReview", reviewViewModel);
        //}
        public async Task<IActionResult> AddReview(HotelAndReviewViewModel reviewViewModel)
        {
            //if (!ModelState.IsValid) { return RedirectToAction("Hotel", "Hotels", new { id = reviewViewModel.ReviewHotelId }); }

            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ApplicationUser user = await userManager.FindByNameAsync(reviewViewModel.ReviewUserName);

            Hotel hotel = hotelRepo.GetById(reviewViewModel.ReviewHotelId);

            var review = new Review
            {
                HotelId = reviewViewModel.ReviewHotelId,
                Content = reviewViewModel.ReviewContent,
                ReviewDate = DateTime.Now,
                IsDeleted = false,
                //Hotel = hotel,
                StarNumber = 0,
                User = user,


            };
            //UserReview userReview = new UserReview()
            //{
            //    ReviewId = review.Id,
            //    UserId = user.Id,
            //    User = user,
            //    Review = review

            //};
            //review.UserReview = userReview;
            //review.Hotel = hotel;

            reviewRepo.Insert(review);
            //userReviewRepo.Insert(userReview);
            reviewRepo.Save();





            //pp-name-date-content
            await hubContext.Clients.All.SendAsync("ReceiveReview", user.ProfilePictureURL, user.UserName, reviewViewModel.ReviewContent, review.ReviewDate.ToString("M/d/yyyy h:mm:ss tt"), reviewViewModel.ReviewHotelId);





            //return Ok();
            return RedirectToAction("Hotel", "Hotels", new { id = reviewViewModel.ReviewHotelId });

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
