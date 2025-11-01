using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class StatisticsDashboard2 : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.portfolios = c.Portfolios.Count();
            ViewBag.messages = c.Messages.Count();
            ViewBag.services = c.Services.Count();

            return View();
        }
    }
}
