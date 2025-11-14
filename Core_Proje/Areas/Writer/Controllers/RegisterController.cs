using Core_Proje.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class RegisterController : Controller
    {

        private readonly UserManager<WriteUser> _userManager;

        public RegisterController(UserManager<WriteUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                WriteUser w = new WriteUser()
                {
                    Name = user.Name,
                    UserName = user.UserName,
                    Email = user.Mail,
                    SurName = user.Surname,
                    ImageUrl = user.ImageUrl



                };
                var result = await _userManager.CreateAsync(w, user.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
 
            return View();
        }
    }
}
