using KindergartenSystem.Services.Data;
using KindergartenSystem.Services.Data.Interfaces;
using KindergartenSystem.Web.Infrastructure.Extensions;
using KindergartenSystem.Web.ViewModels.Child;
using KindergartenSystem.Web.ViewModels.Parent;
using KindergartenSystem.Web.ViewModels.Teacher;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet]
        public async Task<IActionResult> SetAsTeacher(string userId)
        {
            bool userExists = await _userService.UserExistsByIdAsync(userId);
            if (!userExists)
            {
                return BadRequest("There is no user with provided Id");

            }
            bool isAlreadyTeacher = await _userService.TeacherAlreadyExistsAsync(userId);
            if (isAlreadyTeacher)
            {

                return BadRequest("The user is already teacher");
            }
           
            return View();


        }
        [HttpPost]
        public async Task<IActionResult> SetAsTeacher(string userId, CreateTeacherFromUserFormModel model)
        {
            bool userExists = await _userService.UserExistsByIdAsync(userId);
            if (!userExists)
            {
                return BadRequest("There is no user with provided Id");

            }
            bool isAlreadyTeacher = await _userService.TeacherAlreadyExistsAsync(userId);
            if (isAlreadyTeacher)
            {
                return BadRequest("The user is already teacher");
            }
            bool classGroupExists = await _userService.ClassGroupExistsById(model.ClassGroupId);
            if (!classGroupExists)
            {
                ModelState.AddModelError(nameof(model.ClassGroupId), "Invalid class group!");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }



            try
            {
                await _userService.CreateTeacherAsync(userId, model);
            }
            catch (Exception)
            {


                return RedirectToAction("All", "User", new { area = "Admin" });
            }

            return RedirectToAction("All", "User", new { area = "Admin" });
            //FOR NOW!!
        }
    }


}

