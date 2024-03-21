using Microsoft.AspNetCore.Mvc;

namespace KindergartenSystem.Web.Controllers
{
    public class KindergartenController : Controller
    {
        public async Task<IActionResult> About()
        {
            return View();
        }
    }
}
