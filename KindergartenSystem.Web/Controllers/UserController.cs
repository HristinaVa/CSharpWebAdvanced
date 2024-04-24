using Griesoft.AspNetCore.ReCaptcha;
using KindergartenSystem.Data.Models;
using KindergartenSystem.Web.ViewModels.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static KindergartenSystem.Common.GeneralApplicationConstants;

namespace KindergartenSystem.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;


        public UserController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IPasswordHasher<ApplicationUser> passwordHasher)

        {
            _signInManager = signInManager;
            _userManager = userManager;
            _passwordHasher = passwordHasher;
        }
       
        public async Task<IActionResult> SeedUserLogin(LoginFormModel model)
        {
            var seededUsers = new Dictionary<string, string>
    {
        { AdminEmail, AdminPassword },
        { "username@user.com", UserPassword },
        { "userparent@user.com", UserParentPassword }
    };
            string userEmail = model.Email;
             string userPassword = model.Password;
            foreach (var item in seededUsers)
            {

                string email = item.Key;
                string password = item.Value;
                if (userEmail == email)
                {
                    var user = await _userManager.FindByEmailAsync(userEmail);
                    if (user != null && userPassword == password)
                    {


                        await _signInManager.SignInAsync(user, isPersistent: false);

                        return RedirectToAction("Index", "Home"); 

                    }
                }

            }
            return RedirectToAction("Login", "User");

        }
       

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateRecaptcha(Action = nameof(Register), ValidationFailedAction = ValidationFailedAction.ContinueRequest)]
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
            await _userManager.SetUserNameAsync(applicationUser, model.Email);

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
        
        [HttpGet]
        public async Task<IActionResult> Login(string? retunUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            var model = new LoginFormModel()
            {
                ReturnUrl = retunUrl
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(401);

            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (!result.Succeeded)
            {
                var seedLoginResult = await SeedUserLogin(model);

                if (seedLoginResult is RedirectToActionResult)
                {
                    return seedLoginResult;
                }
                else
                {
                    return BadRequest();
                }
            }

            return Redirect(model.ReturnUrl ?? "/Home/Index");
        }
       
    }

}
    

