using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static KindergartenSystem.Common.GeneralApplicationConstants;

namespace KindergartenSystem.Web.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles=AdminRoleName)]
    public class BaseAdminControlleer : Controller
    {
       
    }
}
