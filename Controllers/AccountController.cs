using HotelMangementSystem.Models;
using HotelMangementSystem.Repositories;
using HotelMangementSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelMangementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly IFileRepo fileRepo;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager, IFileRepo fileRepo)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.fileRepo = fileRepo;
        }



        #region Register
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAsync(RegistrationViewModel RegisterForm)
        {

            if (ModelState.IsValid)
            {
                ApplicationUser appFromDb = await userManager.FindByEmailAsync(RegisterForm.Email);
                if (appFromDb == null)
                {
                    ApplicationUser newUser = new ApplicationUser()
                    {
                        UserName = RegisterForm.UserName,
                        Email = RegisterForm.Email,
                        PhoneNumber = RegisterForm.PhoneNumber,
                        PasswordHash = RegisterForm.Password,
                        //ProfilePic = RegisterForm.ProfilePic

                    };
                    var path = "";
                    if (RegisterForm.ProfilePic.Length > 0)
                    {
                        path = await fileRepo.Upload(RegisterForm.ProfilePic, "/images/profilePictures/", RegisterForm.UserName);
                        //if(path) // in error

                    }
                    newUser.ProfilePictureURL = path;









                    if (userManager.Users.Count() == 0)
                    {
                        ApplicationRole GuestRole = new ApplicationRole()
                        {
                            Name = "Guest"
                        };
                        ApplicationRole HotelAdmin = new ApplicationRole()
                        {
                            Name = "HotelAdmin"
                        };

                        IdentityResult HotelAdminResult = await roleManager.CreateAsync(HotelAdmin);
                        IdentityResult GuestRoleResult = await roleManager.CreateAsync(GuestRole);
                        ApplicationRole role = new ApplicationRole()
                        {
                            Name = "TopAdmin"
                        };

                        IdentityResult roleResult = await roleManager.CreateAsync(role);



                        if (roleResult.Succeeded)
                        {
                            IdentityResult UserResult = await userManager.CreateAsync(newUser, RegisterForm.Password);
                            if (UserResult.Succeeded)
                            {
                                await userManager.AddToRoleAsync(newUser, "TopAdmin");
                                await signInManager.SignInAsync(newUser, false);
                                return RedirectToAction("Index", "Home");
                            }
                            foreach (var item in UserResult.Errors)
                            {
                                ModelState.AddModelError("", item.Description);
                            }
                        }
                        foreach (var item in roleResult.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }


                    }
                    else
                    {

                        IdentityResult UserResult = await userManager.CreateAsync(newUser, RegisterForm.Password);
                        if (UserResult.Succeeded)
                        {
                            await userManager.AddToRoleAsync(newUser, "Guest");

                            await signInManager.SignInAsync(newUser, false);
                            return RedirectToAction("Index", "Home");
                        }
                        foreach (var item in UserResult.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email is already taken.");
                }
            }




            return View("Register", RegisterForm);
        }



        #endregion

        #region Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(LoginViewModel loginForm)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindByEmailAsync(loginForm.Email);
                if (user != null)
                {
                    bool found = await userManager.CheckPasswordAsync(user, loginForm.Password);
                    if (found)
                    {
                        await signInManager.SignInAsync(user, loginForm.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid login.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login.");
                }
            }
            return View("Login", loginForm);
        }
        #endregion

        #region Logout
        public async Task<IActionResult> Logout()
        {



            await signInManager.SignOutAsync();
            CartController.EmptyLists();

            return RedirectToAction("Login", "Account");

        }
        #endregion

    }
}
