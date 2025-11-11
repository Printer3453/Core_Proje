using Core_Proje.Areas.Writer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(UserRegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                // Kayıt işlemleri burada yapılacak
                //return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
