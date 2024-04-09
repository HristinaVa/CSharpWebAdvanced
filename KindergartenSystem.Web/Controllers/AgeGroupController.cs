using KindergartenSystem.Services.Data;
using KindergartenSystem.Services.Data.Interfaces;
using KindergartenSystem.Web.ViewModels.AgeGroup;
using KindergartenSystem.Web.ViewModels.Child;
using Microsoft.AspNetCore.Mvc;

namespace KindergartenSystem.Web.Controllers
{
    public class AgeGroupController : Controller
    {
        private readonly IAgeGroupService _ageGroupService;
        public AgeGroupController(IAgeGroupService ageGroupService)
        {
            _ageGroupService = ageGroupService;
        }
        public async Task<IActionResult> All(int id)
        {
            IEnumerable<AllAgeGroupsViewModel> models = await _ageGroupService.AllAgeGroupsAsync(id);
            return View(models);
        }
        public async Task<IActionResult> Details(int id)
        {
            var ageGroupExists = await _ageGroupService.ExistsById(id);
            if (!ageGroupExists)
            {

                return StatusCode(400);// for now temp data
            }

            try
            {
                var model = await _ageGroupService.GetAgeGroupDetailsAsync(id);
                return View(model);

            }
            catch (Exception)
            {

                return StatusCode(400);
            }
        }
    }
}
