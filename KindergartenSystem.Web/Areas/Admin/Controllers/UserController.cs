using KindergartenSystem.Data.Models.Enums;
using KindergartenSystem.Services.Data;
using KindergartenSystem.Services.Data.Interfaces;
using KindergartenSystem.Services.Data.Models.Teacher;
using KindergartenSystem.Web.ViewModels.Child;
using KindergartenSystem.Web.ViewModels.Teacher;
using static KindergartenSystem.Common.GeneralApplicationConstants;
using Microsoft.AspNetCore.Mvc;
using KindergartenSystem.Web.ViewModels.ClassGroup;
using KindergartenSystem.Web.ViewModels.AgeGroup;
using KindergartenSystem.Web.Infrastructure.Extensions;

namespace KindergartenSystem.Web.Areas.Admin.Controllers
{
    public class UserController : BaseAdminControlleer
    {
        private readonly IUserService _userService;
        private readonly ITeacherService _teacherService;
        private readonly IAgeGroupService _ageGroupService;
        private readonly IClassGroupService _classGroupService;
        public UserController(IUserService userService, ITeacherService teacherService, IAgeGroupService ageGroupService, IClassGroupService classGroupService)
        {
            _userService = userService;
            _teacherService = teacherService;
            _ageGroupService = ageGroupService;
            _classGroupService = classGroupService;
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
        }
        public async Task<IActionResult> PendingParents()
        {
            var pendingParents = await _userService.GetPendingParentsAsync();
            return View(pendingParents);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStatus(string parentId, ParentStatus newStatus)
        {
            if (string.IsNullOrEmpty(parentId))
            {
                return BadRequest("Parent Id is missing.");
            }


            var result = await _userService.UpdateParentStatusAsync(parentId, newStatus);

            if (!result)
            {
                return NotFound($"Parent with ID {parentId} not found.");
            }

            return RedirectToAction("PendingParents");
        }
        [HttpGet]
        public async Task<IActionResult> AllTeachers([FromQuery] AllTeachersQueryModel model)
        {
            AllTeachersServiceModel serviceModel = await _teacherService.AllTeachersAsync(model);

            model.Teachers = serviceModel.Teachers;
            model.AllTeachers = serviceModel.AllTeachersCount;
            model.AgeGroups = await _ageGroupService.AllAgeGroupNumbersAsync();

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> EditTeacher(string id)
        {
            var teacherExists = await _teacherService.TeacherExistsById(id);
            if (!teacherExists)
            {
                return StatusCode(404);//temp data
            }


            try
            {
                var model = await _teacherService.GetTeacherForEditAsync(id);
                model.ClassGroups = await _classGroupService.GetClassGroupsAsync();
                return View(model);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }
        [HttpPost]
        public async Task<IActionResult> EditTeacher(string id, TeacherFormModel model)
        {
            var teacherExists = await _teacherService.TeacherExistsById(id);
            if (!teacherExists)
            {
                return StatusCode(400);//temp data
            }


            try
            {
                await _teacherService.EditTeacherInfoAsync(id, model);
            }
            catch (Exception)
            {

                ModelState.AddModelError(string.Empty, "Unexpected error! Pleace contact administrator!");
                model.ClassGroups = await _classGroupService.GetClassGroupsAsync();

                return View(model);
            }
            return RedirectToAction("AllTeachers", "User");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteTeacher(string id)
        {
            var teacherExists = await _teacherService.TeacherExistsById(id);
            if (!teacherExists)
            {
                return StatusCode(400);//temp data
            }

            try
            {
                var model = await _teacherService.GetDeleteTeacherInfoAsync(id);
                return View(model);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTeacher(string id, TeacherDeleteInfoViewModel model)
        {
            var teacherExists = await _teacherService.TeacherExistsById(id);
            if (!teacherExists)
            {
                return StatusCode(400);//temp data
            }


            try
            {
                await _teacherService.DeleteTeacherAsync(id);

                return RedirectToAction("AllTeachers", "User");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        [HttpGet]
        public async Task<IActionResult> AddClassGroup()
        {

            bool isUserAdmin = User.IsInRole(AdminRoleName);
            if (!isUserAdmin)
            {
                return RedirectToAction("Index", "Home");
            }
            try
            {
                ClassGroupViewModel model = new ClassGroupViewModel()
                {
                    AgeGroups = await _ageGroupService.GetAgeGroupsAsync()
                };
                return View(model);
            }
            catch (Exception)
            {

                return BadRequest("Unexpexted error, please contatact with administrator!");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddClassGroup(ClassGroupViewModel model)
        {
            bool isUserAdmin = User.IsInRole(AdminRoleName);
            if (!isUserAdmin)
            {
                return RedirectToAction("Index", "Home");
            }
            bool ageGroupExists = await _ageGroupService.ExistsById(model.AgeGroupId);
            if (!ageGroupExists)
            {
                ModelState.AddModelError(nameof(model.AgeGroupId), "Invalid age group!");
            }
            
            if (!ModelState.IsValid)
            {
                model.AgeGroups = await _ageGroupService.GetAgeGroupsAsync();
                return View(model);
            }
            try
            {
                await _classGroupService.CreateClassGroupAsync(model);
                int ageGroupId = model.AgeGroupId;
                return RedirectToAction("Details", "AgeGroup", new { id = ageGroupId, area = "" });
            }
            catch (Exception)
            {

                ModelState.AddModelError(string.Empty, "Unexpected error occured while adding new group!");

                model.AgeGroups = await _ageGroupService.GetAgeGroupsAsync();
                return View(model);
            }

        }
    }
}
    




