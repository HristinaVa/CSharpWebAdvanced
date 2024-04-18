using KindergartenSystem.Services.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KindergartenSystem.Web.Areas.Admin.Controllers
{
    public class UserController : BaseAdminControlleer
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> All()
        {
            var users = await _userService.GetUsersAsync();
            return View(users);
        }

        
    }
}
