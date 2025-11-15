using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize]
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
    }
}
