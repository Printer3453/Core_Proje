using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ServiceController : Controller
    {
        ServiceManager _serviceManager= new ServiceManager(new EfServiceDal());
        public IActionResult Index()
        {
            ViewBag.v1 = "Hizmet Lİstesi ";
            ViewBag.v2 = "Hizmetler";
            ViewBag.v3 = "Hizmet Listesi ";
            var values = _serviceManager.TGetList();
            return View(values);
        }


        [HttpGet]
        public IActionResult AddService()
        {
            ViewBag.v1 = "Hizmet Lİstesi ";
            ViewBag.v2 = "Hizmetler";
            ViewBag.v3 = "Hizmet Ekleme ";

            return View();
        }
        [HttpPost]
        public IActionResult AddService(Service service)
        {

            _serviceManager.TAdd(service);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteService(int id)
        {
            var value = _serviceManager.TGetByID(id);
            _serviceManager.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditService(int id)
        {
            ViewBag.v1 = "Hizmet Lİstesi ";
            ViewBag.v2 = "Hizmetler";
            ViewBag.v3 = "Hizmet Güncelleme ";

            var value = _serviceManager.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditService(Service service)
        {
            _serviceManager.TUpdate(service);
            return RedirectToAction("Index");
        }
    }
}
