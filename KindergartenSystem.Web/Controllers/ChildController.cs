using KindergartenSystem.Services.Data.Interfaces;
using KindergartenSystem.Web.Infrastructure.Extensions;
using KindergartenSystem.Web.ViewModels.Child;
using KindergartenSystem.Web.ViewModels.ClassGroup;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KindergartenSystem.Web.Controllers
{
    [Authorize]
    public class ChildController : Controller
    {
        private readonly IClassGroupService _classGroupService;
        private readonly ITeacherService _teacherService;
        public ChildController(IClassGroupService classGroupService, ITeacherService teacherService)
        {
            _classGroupService = classGroupService;
            _teacherService = teacherService;
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            bool isTeacher = await _teacherService.TeacherExistsByUserId(User.GetId()!);
            if (!isTeacher)
            {
                return RedirectToAction("Index", "Home");
            }
            ChildFormModel model = new ChildFormModel()
            {  
                ClassGroups = await _classGroupService.GetClassGroupsAsync()
            };
            return View(model);
        }
    }
}
