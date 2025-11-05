using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
    public class DefaultController : Controller
    {
        [Area("Writer")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
