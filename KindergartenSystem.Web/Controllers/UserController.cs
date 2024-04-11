using KindergartenSystem.Data.Models;
using KindergartenSystem.Web.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KindergartenSystem.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;

        public UserController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IUserStore<ApplicationUser> userStore)
        {
            
            _signInManager = signInManager;
            _userManager = userManager;
            _userStore = userStore;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var applicationUser = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            await _userManager.SetEmailAsync(applicationUser, model.Email);
            await _userManager.SetUserNameAsync(applicationUser, model.FirstName);

            IdentityResult result =
                await _userManager.CreateAsync(applicationUser, model.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model);
            }

            await _signInManager.SignInAsync(applicationUser, false);

            return RedirectToAction("Index", "Home");
        }
    }
}
