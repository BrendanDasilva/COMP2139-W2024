using Microsoft.AspNetCore.Mvc;
using Assignment1.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Assignment1.Models;
using Assignment1.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
namespace Assignment1.Controllers
{
    public class UserRolesController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRolesController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        private async Task<List<string>> GetUserRolesAsync(ApplicationUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var userRolesViewModel = new List<UserRoleViewModel>();

            foreach (ApplicationUser u in users)
            {
                var thisViewModel = new UserRoleViewModel();
                thisViewModel.UserID = u.Id;
                thisViewModel.FirstName = u.FirstName;
                thisViewModel.LastName = u.LastName;
                thisViewModel.Email = u.Email;
                thisViewModel.Roles = await GetUserRolesAsync(u);
                userRolesViewModel.Add(thisViewModel);
            }
            return View(userRolesViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Manage(string userID)
        {
            ViewBag.userID = userID;
            var user = await _userManager.FindByIdAsync(userID);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userID} cannot be found";
                return View("NotFound");
            }

            ViewBag.UserName = user.UserName;
            var model = new List<ManageUserRolesViewModel>();
            foreach (var role in _roleManager.Roles)
            {
                var userRolesViewModel = new ManageUserRolesViewModel
                {
                    RolesId = role.Id,
                    RoleName = role.Name
                };

                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.Selected = true;
                }
                else
                {
                    userRolesViewModel.Selected = false;
                }
                model.Add(userRolesViewModel);
            }
            return View(model);
        }



        [HttpPost]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> Manage(List<ManageUserRolesViewModel> model, string userID)
        {
            var user = await _userManager.FindByIdAsync(userID);
            if (user == null)
            {
                return View();
            }

            // Get the roles for the user
            var roles = await _userManager.GetRolesAsync(user);

            // Remove the user from all current roles
            var result = await _userManager.RemoveFromRolesAsync(user, roles);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user from roles.");
                return View(model);
            }

            // Add the user to the selected roles
            result = await _userManager.AddToRolesAsync(user, model.Where(x => x.Selected).Select(y => y.RoleName));
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add user to roles.");
                return View(model);
            }

            return RedirectToAction("Index");
        }
    }
}
