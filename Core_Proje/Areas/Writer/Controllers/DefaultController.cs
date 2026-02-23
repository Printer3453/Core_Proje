using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize]
    [Route("Writer/[controller]/[action]")]
    public class DefaultController : Controller
    {
        AnnouncementManager _announcementManager = new AnnouncementManager(new EfAnnouncementDal());
        //Giriş yapan yazarın duyurular sayfasını açar
        //giriş yapan yazarın bilgilerini çekmek için User.Identity.Name kullanılır
        public IActionResult Index()
        {
            var values = _announcementManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AnnouncementDetails(int id)
        {
            var values = _announcementManager.TGetByID(id);
            return View(values);
        }
    }
}
