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

        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }


    }
}
