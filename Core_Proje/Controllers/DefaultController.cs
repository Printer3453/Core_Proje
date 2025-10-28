using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class DefaultController : Controller
    {
        /* Bu controller, varsayılan (default) sayfa isteklerini yönetir. 
         * Index metodu, ana sayfa için bir görünüm döndürür.
         */
        public IActionResult Index()
        {



            return View();
        }

        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public PartialViewResult NavbarPartial()
        {

            return PartialView();
        }

        [HttpPost]
        public PartialViewResult SendMessage(Message p)
        {
            MessageManager messageManager = new MessageManager(new EfMessageDal());
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Status = true;
            messageManager.TAdd(p);
            return PartialView(); 
        }


    }
}
