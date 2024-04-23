﻿using KindergartenSystem.Data.Models.Enums;
using KindergartenSystem.Services.Data.Interfaces;
using KindergartenSystem.Services.Data.Models.Teacher;
using KindergartenSystem.Web.ViewModels.Teacher;
using Microsoft.AspNetCore.Mvc;

namespace KindergartenSystem.Web.Areas.Admin.Controllers
{
    public class UserController : BaseAdminControlleer
    {
        private readonly IUserService _userService;
        private readonly ITeacherService _teacherService;
        private readonly IAgeGroupService _ageGroupService;
        public UserController(IUserService userService, ITeacherService teacherService, IAgeGroupService ageGroupService)
        {
            _userService = userService;
            _teacherService = teacherService;
            _ageGroupService = ageGroupService;
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

    }
}
    




