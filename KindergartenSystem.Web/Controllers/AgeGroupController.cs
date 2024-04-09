using KindergartenSystem.Services.Data.Interfaces;
using KindergartenSystem.Web.ViewModels.AgeGroup;
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
        //public async Task<IActionResult> Details(int id)
        //{

        //}
    }
}
