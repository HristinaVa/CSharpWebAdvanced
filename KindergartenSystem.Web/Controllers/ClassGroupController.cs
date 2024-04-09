using Microsoft.AspNetCore.Mvc;

namespace KindergartenSystem.Web.Controllers
{
    public class ClassGroupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
