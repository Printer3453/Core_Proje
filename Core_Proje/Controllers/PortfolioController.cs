using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioManager _portfolioManager = new PortfolioManager(new EfPortfolioDal());


        public IActionResult Index()
        {
            ViewBag.v1 = "Proje Lİstesi ";
            ViewBag.v2 = "Projelerim";
            ViewBag.v3 = "Projele Listesi ";
            var values = _portfolioManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddPortfolio()
        {
            ViewBag.v1 = "Proje Lİstesi ";
            ViewBag.v2 = "Projelerim ";
            ViewBag.v3 = "Proje Ekleme ";
            return View();
        }
        [HttpPost]
        public IActionResult AddPortfolio(Portfolio portfolio)
        {
            _portfolioManager.TAdd(portfolio);
            return RedirectToAction("Index");

        }
    }
}
