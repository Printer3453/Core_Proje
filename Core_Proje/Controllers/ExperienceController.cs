using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ExperienceController : Controller
    {
        ExperienceManager experianceManager = new ExperienceManager(new EfExperienceDal());
        public IActionResult Index()
        {
            var values = experianceManager.TGetList();
            return View(values);
        }
    }
}
