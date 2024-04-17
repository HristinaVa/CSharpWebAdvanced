using Microsoft.AspNetCore.Mvc;

namespace KindergartenSystem.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminControlleer
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
