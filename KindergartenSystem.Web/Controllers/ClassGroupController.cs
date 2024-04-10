using KindergartenSystem.Services.Data.Interfaces;
using KindergartenSystem.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace KindergartenSystem.Web.Controllers
{
    public class ClassGroupController : Controller
    {
        private readonly IClassGroupService _classGroupService;
        public ClassGroupController(IClassGroupService classGroupService)
        {
            _classGroupService = classGroupService;
        }
        public async Task<IActionResult> Details(int id, string information)
        {
            var classGroupExists = await _classGroupService.ExistsById(id);
            if (!classGroupExists)
            {
                return StatusCode(404);
            }
            var model = await _classGroupService.GetDetailsAsync(id);
            if (ViewModelsExtencions.GetUrlInfomation(model) != information)
            {
                return StatusCode(404);

            }
            return View(model);
        }
    }
}
