using KindergartenSystem.Services.Data;
using KindergartenSystem.Services.Data.Interfaces;
using KindergartenSystem.Web.Infrastructure.Extensions;
using KindergartenSystem.Web.ViewModels.Parent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KindergartenSystem.Web.Controllers
{
    public class ParentController : Controller
    {
        private readonly IParentService _parentService;

        public ParentController(IParentService parenttService)
        {
            _parentService = parenttService; 
        
        }
        [HttpGet]
        public async Task<IActionResult> IAmParent()
        {
            string? userId = User.GetId();
            bool isAlreadyParent = await _parentService.ParentExistsByUserId(userId!);
            if (isAlreadyParent)
            {
                
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> IAmParent(IAmParentFormModel model)
        {
            string? userId = User.GetId();
            bool isAlreadyParent = await _parentService.ParentExistsByUserId(userId);
            if (isAlreadyParent)
            {
                return RedirectToAction("Index", "Home");
            }
            bool isPhoneAlreadyExists =
                await _parentService.ParentExistsByPhoneNumberAsync(model.PhoneNumber);
            if (isPhoneAlreadyExists)
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), "There is already parent with this phone number");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

           

            try
            {
                await _parentService.Create(userId, model);
            }
            catch (Exception)
            {
               

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");//FOR NOW!!
        }
    }
}
    

