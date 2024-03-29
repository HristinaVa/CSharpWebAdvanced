using KindergartenSystem.Services.Data.Interfaces;
using KindergartenSystem.Services.Data.Models.Child;
using KindergartenSystem.Web.Infrastructure.Extensions;
using KindergartenSystem.Web.ViewModels.Child;
using KindergartenSystem.Web.ViewModels.ClassGroup;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            ChildFormModel model = new ChildFormModel()
            {  
                ClassGroups = await _classGroupService.GetClassGroupsAsync()
            };
            return View(model);
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
                await _childService.CreateChildAsync(model, parentId);
            }
            catch (Exception)
            {

                ModelState.AddModelError(string.Empty, "Unexpected error occured while adding new child!");
                
                model.ClassGroups = await _classGroupService.GetClassGroupsAsync();
                return View(model);
            }
            return RedirectToAction("Index", "Home");//for now
        }
        [HttpGet]
        public async Task<IActionResult> AllChildren([FromQuery]AllChildrenByGroupQueryModel model)
        {
            AllChildrenServiceModel serviceModel = await _childService.AllChildrenAsync(model);

            model.Children = serviceModel.Children;
            model.AllChildren = serviceModel.AllChilderenCount;
            model.AgeGroups = await _ageGroupService.AllAgeGroupNumbersAsync();
            model.ClassGroups = await _classGroupService.AllClassGroupsTitlesAsync();
            


            return View(model);
        }
        
    }
}
