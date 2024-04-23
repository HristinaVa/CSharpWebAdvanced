using KindergartenSystem.Services.Data;
using KindergartenSystem.Services.Data.Interfaces;
using KindergartenSystem.Web.Infrastructure.Extensions;
using KindergartenSystem.Web.ViewModels.Child;
using KindergartenSystem.Web.ViewModels.Workshop;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KindergartenSystem.Web.Controllers
{
    [Authorize]

    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IChildService _childService;
        public TeacherController(ITeacherService teacherService, IChildService childService)
        {
            _teacherService = teacherService;
            _childService = childService;

        }
        [HttpGet]
        public async Task<IActionResult> AddItem(string id)
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
                WorkshopFormModel model = new WorkshopFormModel()
                {
                    
                };
                return View(model);
            }
            catch (Exception)
            {

                return BadRequest("Unexpexted error, please contatact with administrator!");
            }


        }

        [HttpPost]
        public async Task<IActionResult> AddItem(string id, WorkshopFormModel model)
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
                await _teacherService.AddWorkshopAsync(model, id);
                return RedirectToAction("Mine", "Child");//for now
            }
            catch (Exception)
            {

                ModelState.AddModelError(string.Empty, "Unexpected error occured while adding new workshop item!");

                return View(model);
            }

        }
    }
}
