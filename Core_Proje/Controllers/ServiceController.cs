using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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

    }
}
