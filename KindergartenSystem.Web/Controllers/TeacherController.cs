using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KindergartenSystem.Web.Controllers
{
    [Authorize]
    public class TeacherController : Controller
    {
        public async Task<IActionResult> AddParent()
        {
            return View();
        }
    }
}
