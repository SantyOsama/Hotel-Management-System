using HotelMangementSystem.Models;
using HotelMangementSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Data;
using System.Threading.Tasks;

namespace HotelMangementSystem.Controllers
{
    //[Authorize(Roles = "TopAdmin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public RoleController(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        #region Add New Role
        [Authorize(Roles = "TopAdmin")]
        public IActionResult AddNewRole()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewRole(NewRoleViewModel NewRoleName)
        {
            ApplicationRole NewRole = new ApplicationRole() { Name = NewRoleName.Name };

            if (ModelState.IsValid)
            {
                IdentityResult roleResult = await roleManager.CreateAsync(NewRole);
                if (roleResult.Succeeded)
                {
                    ViewBag.success = true;
                    return View();


                }
                else
                {
                    foreach (var item in roleResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    ViewBag.fail = true;
                    return View();
                }
            }
            else
            {
                return View();
            }

            return View();
        }

        #endregion




        #region Assign Role To user
        [Authorize(Roles = "TopAdmin")]

        [HttpGet]
        public IActionResult AssignRole()

        {
            RolesAndUsersViewModel rolesAndUsers = new RolesAndUsersViewModel();
            rolesAndUsers.Users = userManager.Users.ToList();
            rolesAndUsers.Roles = roleManager.Roles.ToList();
            ViewBag.UserAndRoles = rolesAndUsers;
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignRole(AssignRoleModel AssignRoleFrom)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser UserIdExists = await userManager.FindByIdAsync(AssignRoleFrom.UserId);
                if (UserIdExists != null)
                {
                    bool RoleExists = await roleManager.RoleExistsAsync(AssignRoleFrom.RoleName);
                    if (RoleExists)
                    {
                        var AddRole = await userManager.AddToRoleAsync(UserIdExists, AssignRoleFrom.RoleName);
                        if (AddRole.Succeeded)
                        {
                            ViewBag.RoleAdded = true;
                            RolesAndUsersViewModel rolesAndUserss = new RolesAndUsersViewModel();
                            rolesAndUserss.Users = userManager.Users.ToList();
                            rolesAndUserss.Roles = roleManager.Roles.ToList();
                            ViewBag.UserAndRoles = rolesAndUserss;
                            // return View();
                        }
                        else
                        {
                            foreach (var error in AddRole.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }

                    }
                    else
                    {
                        ViewBag.RoleNotAdded = true;
                        ModelState.AddModelError("", "Role is not exists");

                    }

                }
                else
                {
                    ViewBag.RoleNotAdded = true;
                    ModelState.AddModelError("", "User is not exists");

                }
            }
            RolesAndUsersViewModel rolesAndUsers = new RolesAndUsersViewModel();
            rolesAndUsers.Users = userManager.Users.ToList();
            rolesAndUsers.Roles = roleManager.Roles.ToList();
            ViewBag.UserAndRoles = rolesAndUsers;
            return View(AssignRoleFrom);

        }
        #endregion


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddAdminRole(string Email)
        //{
        //    if (string.IsNullOrEmpty(Email))
        //    {
        //        ModelState.AddModelError("", "Email cannot be empty.");
        //        return View();
        //    }
        //    var user = await userManager.FindByEmailAsync(Email);
        //    if (user == null)
        //    {
        //        ModelState.AddModelError("", "User not found.");
        //        return View();
        //    }
        //    if (!await roleManager.RoleExistsAsync("Admin"))
        //    {
        //        await roleManager.CreateAsync(new ApplicationRole { Name = "Admin" });
        //    }
        //    var result = await userManager.AddToRoleAsync(user, "Admin");
        //    if (result.Succeeded)
        //    {
        //        TempData["SuccessMessage"] = $"User {Email} has been assigned as Admin.";
        //        return RedirectToAction("RoleList");
        //    }
        //    else
        //    {
        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError("", error.Description);
        //        }
        //    }
        //    return View("AddAdminRole");
        //}
    }
}