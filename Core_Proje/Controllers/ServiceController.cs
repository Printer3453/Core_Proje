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
            var values = _serviceManager.TGetList();
            return View(values);
        }

    }
}
