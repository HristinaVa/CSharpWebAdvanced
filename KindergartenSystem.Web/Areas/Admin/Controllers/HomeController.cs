using Microsoft.AspNetCore.Mvc;

namespace KindergartenSystem.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminControlleer
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Get()
        {
            return View();
        }
        public ActionResult<string> GetSecretCode()
        {
            string newGuid = Guid.NewGuid().ToString();
            return newGuid;

        }
    }
}
