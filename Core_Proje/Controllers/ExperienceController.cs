using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ExperienceController : Controller
    {
        ExperienceManager _experienceManager = new ExperienceManager(new EfExperienceDal());
        public IActionResult Index()
        {
            ViewBag.v1 = "Deneyim Lİstesi ";
            ViewBag.v2 = "Deneyimler";
            ViewBag.v3 = "Deneyim Listesi ";
            var values = _experienceManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddExperience()
        {
            ViewBag.v1 = "Deneyim Ekleme ";
            ViewBag.v2 = "Deneyimler ";
            ViewBag.v3 = "Deneyim Ekleme ";

            return View();
        }
        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            
            _experienceManager.TAdd(experience);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteExperience(int id)
        {
            var value = _experienceManager.TGetByID(id);
            _experienceManager.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditExperience(int id)
        {
            ViewBag.v1 = "Deneyim Güncelleme ";
            ViewBag.v2 = "Deneyimler ";
            ViewBag.v3 = "Deneyim Güncelleme ";
            var value = _experienceManager.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditExperience(Experience experience)
        {
            _experienceManager.TUpdate(experience);
            return RedirectToAction("Index");
        }





    }
}
