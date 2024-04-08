using KindergartenSystem.Services.Data;
using KindergartenSystem.Services.Data.Interfaces;
using KindergartenSystem.Web.ViewModels.Child;
using KindergartenSystem.Web.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace KindergartenSystem.Web.Controllers
{
    public class KindergartenController : Controller
    {
        private readonly IKindergartenService _kindergartenService;
        public KindergartenController(IKindergartenService kindergartenService)
        {
            _kindergartenService = kindergartenService;
        }
        [HttpGet]
        public async Task<IActionResult> About()
        {
            //var kindergartenExists = await _kindergartenService.ExistsByIdAsync(id);
            //if (!kindergartenExists)
            //{

            //    return StatusCode(400);// for now temp data
            //}

            
            
                IndexViewModel model = await _kindergartenService.AboutAsync();
                return View(model);

            
            
            
        }
    }
}
