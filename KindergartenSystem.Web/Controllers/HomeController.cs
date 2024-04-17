using KindergartenSystem.Services.Data.Interfaces;
using KindergartenSystem.Web.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using static KindergartenSystem.Common.GeneralApplicationConstants;



namespace KindergartenSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IKindergartenService _kindergartenService;

        public HomeController(IKindergartenService kindergartenService)
        {
            _kindergartenService = kindergartenService;
        }

        public async Task<IActionResult> Index()
        {
            if (User.IsInRole(AdminRoleName))
            {
               return RedirectToAction("Index", "Home", new {Area = AdminAreaName});
            }
            IEnumerable<ImageViewModel> viewModel = await _kindergartenService.AboutInfoAsync();
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 404 || statusCode == 400)
            {
                return View("Error404");
            }
            if (statusCode == 401)
            {
                return View("Error401");
            }
            return View();
        }
    }
}
