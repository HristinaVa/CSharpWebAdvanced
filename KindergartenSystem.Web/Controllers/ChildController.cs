﻿using KindergartenSystem.Services.Data.Interfaces;
using KindergartenSystem.Services.Data.Models.Child;
using KindergartenSystem.Web.Infrastructure.Extensions;
using KindergartenSystem.Web.ViewModels.Child;
using KindergartenSystem.Web.ViewModels.Workshop;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KindergartenSystem.Web.Controllers
{
    [Authorize]
    public class ChildController : Controller
    {
        private readonly IClassGroupService _classGroupService;
        private readonly ITeacherService _teacherService;
        private readonly IChildService _childService;
        private readonly IParentService _parentService;
        private readonly IAgeGroupService _ageGroupService;
        public ChildController(IClassGroupService classGroupService, ITeacherService teacherService,
            IChildService childService, IParentService parentService, IAgeGroupService ageGroupService)
        {
            _classGroupService = classGroupService;
            _teacherService = teacherService;
            _childService = childService;
            _parentService = parentService;
            _ageGroupService = ageGroupService;
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            bool isTeacher = await _teacherService.TeacherExistsByUserId(User.GetId()!);
            if (!isTeacher)
            {
                return RedirectToAction("Index", "Home");
            }
            try
            {
                ChildFormModel model = new ChildFormModel()
                {
                    ClassGroups = await _classGroupService.GetClassGroupsAsync()
                };
                return View(model);
            }
            catch (Exception)
            {

                return BadRequest("Unexpexted error, please contatact with administrator!");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Add(ChildFormModel model)
        {
            bool isTeacher = await _teacherService.TeacherExistsByUserId(User.GetId()!);
            if (!isTeacher)
            {
                return RedirectToAction("Index", "Home");
            }
            bool parentExist = await _parentService.ParentExistsByPhoneNumberAsync(model.ParentPhone);
            if (!parentExist)
            {
                ModelState.AddModelError(nameof(model.ParentPhone), "There is no parent with this phone number!");
            }
            bool classGroupExists = await _classGroupService.ExistsById(model.ClassGroupId);
            if (!classGroupExists)
            {
                ModelState.AddModelError(nameof(model.ClassGroupId), "Invalid class group!");
            }
            if (!ModelState.IsValid)
            {
                model.ClassGroups = await _classGroupService.GetClassGroupsAsync();
                return View(model);
            }
            try
            {
                var parentId = await _parentService.GetParentIdByPhoneAsync(model.ParentPhone);
                string childId = await _childService.CreateChildAsync(model, parentId);
                return RedirectToAction("Details", "Child", new { id = childId });//for now
            }
            catch (Exception)
            {

                ModelState.AddModelError(string.Empty, "Unexpected error occured while adding new child!");

                model.ClassGroups = await _classGroupService.GetClassGroupsAsync();
                return View(model);
            }

        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var childExists = await _childService.ExistsById(id);
            if (!childExists)
            {
                return StatusCode(404);// for now temp data
            }
            var isTeacher = await _teacherService.TeacherExistsByUserId(User.GetId()!);
            if (!isTeacher)
            {
                return StatusCode(401);
            }
            var teacherId = await _teacherService.GetTeacherByUserId(User.GetId()!);
            var isTeacherOfTheChild = await _childService.IsTeacherOfTheGroup(teacherId, id);
            if (!isTeacherOfTheChild && User.IsUserAdmin() == false)
            {
                return StatusCode(401);
            }
            try
            {
                var model = await _childService.GetChildForEditAsync(id);
                model.ClassGroups = await _classGroupService.GetClassGroupsAsync();
                return View(model);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Edit(string id, ChildFormModel model)
        {
            var childExists = await _childService.ExistsById(id);
            if (!childExists)
            {
                return StatusCode(400);// for now temp data
            }
            var isTeacher = await _teacherService.TeacherExistsByUserId(User.GetId()!);
            if (!isTeacher)
            {
                return StatusCode(401);
            }
            var teacherId = await _teacherService.GetTeacherByUserId(User.GetId()!);
            var isTeacherOfTheChild = await _childService.IsTeacherOfTheGroup(teacherId, id);
            if (!isTeacherOfTheChild && User.IsUserAdmin() == false)
            {
                return StatusCode(401);
            }
            try
            {
                await _childService.EditChildInfoAsync(id, model);
            }
            catch (Exception)
            {

                ModelState.AddModelError(string.Empty, "Unexpected error! Pleace contact administrator!");
                model.ClassGroups = await _classGroupService.GetClassGroupsAsync();

                return View(model);
            }
            return RedirectToAction("Details", "Child", new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var childExists = await _childService.ExistsById(id);
            if (!childExists)
            {
                return StatusCode(400);// for now temp data
            }
            var isTeacher = await _teacherService.TeacherExistsByUserId(User.GetId()!);
            if (!isTeacher)
            {
                return StatusCode(401);
            }
            var teacherId = await _teacherService.GetTeacherByUserId(User.GetId()!);
            var isTeacherOfTheChild = await _childService.IsTeacherOfTheGroup(teacherId, id);
            if (!isTeacherOfTheChild && User.IsUserAdmin() == false)
            {
                return StatusCode(401);
            }
            try
            {
                var model = await _childService.GetDeleteChildInfoAsync(id);
                return View(model);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, ChildDeleteInfoViewModel model)
        {
            var childExists = await _childService.ExistsById(id);
            if (!childExists)
            {
                return StatusCode(400);// for now temp data
            }
            var isTeacher = await _teacherService.TeacherExistsByUserId(User.GetId()!);
            if (!isTeacher)
            {
                return StatusCode(401);
            }
            var teacherId = await _teacherService.GetTeacherByUserId(User.GetId()!);
            var isTeacherOfTheChild = await _childService.IsTeacherOfTheGroup(teacherId, id);
            if (!isTeacherOfTheChild && User.IsUserAdmin() == false)
            {
                return StatusCode(401);
            }
            try
            {
                await _childService.DeleteChildAsync(id);

                return RedirectToAction("Mine", "Child");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }


        [HttpGet]
        public async Task<IActionResult> AllChildren([FromQuery] AllChildrenByGroupQueryModel model)
        {
            AllChildrenServiceModel serviceModel = await _childService.AllChildrenAsync(model);

            model.Children = serviceModel.Children;
            model.AllChildren = serviceModel.AllChilderenCount;
            model.AgeGroups = await _ageGroupService.AllAgeGroupNumbersAsync();
            model.ClassGroups = await _classGroupService.AllClassGroupsTitlesAsync();



            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            List<AllChildrenByGroupViewModel> myChildren = new List<AllChildrenByGroupViewModel>();
            var userId = User.GetId();
            var isTeacher = await _teacherService.TeacherExistsByUserId(userId);
            try
            {
                if (isTeacher)
                {
                    var teacherId = await _teacherService.GetTeacherByUserId(userId);
                    myChildren.AddRange(await _childService.AllByTeachersAsync(teacherId));
                }
                else
                {
                    var parentId = await _parentService.GetParentIdByUserAsync(userId);
                    myChildren.AddRange(await _childService.AllByParentsAsync(parentId));

                }
                return View(myChildren);
            }
            catch (Exception)
            {


                return StatusCode(500);
            }


        }
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var childExists = await _childService.ExistsById(id);
            if (!childExists)
            {
                
                return StatusCode(400);// for now temp data
            }

            try
            {
                ChildDetailsViewModel model = await _childService.GetChildDetailsAsync(id);
                return View(model);

            }
            catch (Exception)
            {
                
                return BadRequest("Unexpected error! Pleace contact administrator!");
            }

        }
        [HttpPost]
        public async Task<IActionResult> Missing(string id)
        {
            var childExists = await _childService.ExistsById(id);
            if (!childExists)
            {
                return StatusCode(400);
            }
            var isChildAttending = await _childService.IsAttendingAsync(id);
            if (!isChildAttending)
            {
                return BadRequest("The child is allready missing from class");
            }
            var teacherId = await _teacherService.GetTeacherByUserId(User.GetId()!);
            var isTeacherOfTheChild = await _childService.IsTeacherOfTheGroup(teacherId, id);
            if (!isTeacherOfTheChild && User.IsUserAdmin() == false)
            {
                return StatusCode(401);
            }
            try
            {
                await _childService.SetChildAsMissingFromClassAsync(id);


            }
            catch (Exception)
            {

                return BadRequest("Unexpected error! Pleace contact administrator!");
            }
            return RedirectToAction("Mine", "Child");
        }
        [HttpPost]
        public async Task<IActionResult> Attending(string id)
        {
            var childExists = await _childService.ExistsById(id);
            if (!childExists)
            {
                return StatusCode(400);// for now temp data

            }
            var isChildAttending = await _childService.IsAttendingAsync(id);
            if (isChildAttending)
            {
                return BadRequest("The child is allready attend to class");
            }
            var teacherId = await _teacherService.GetTeacherByUserId(User.GetId()!);
            var isTeacherOfTheChild = await _childService.IsTeacherOfTheGroup(teacherId, id);
            if (!isTeacherOfTheChild && User.IsUserAdmin() == false)
            {
                return StatusCode(401);
            }
            try
            {
                await _childService.SetChildAsAttendingToClassAsync(id);
            }
            catch (Exception)
            {

                return BadRequest("Unexpected error! Pleace contact administrator!");
            }
            return RedirectToAction("Mine", "Child");
        }
        public async Task<IActionResult> Workshops(string id)
        {
            List<WorkshopFormModel> workshops = new List<WorkshopFormModel>();
            workshops.AddRange(await _childService.AllByChildAsync(id));
            return View(workshops);

        }
    }
}
