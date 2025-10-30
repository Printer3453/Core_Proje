using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
            ViewBag.v1 = "Proje Lİstesi ";
            ViewBag.v2 = "Projelerim ";
            ViewBag.v3 = "Proje Ekleme ";

            PortfolioValidatior portfolioValidatior = new PortfolioValidatior();
            ValidationResult results= portfolioValidatior.Validate(portfolio);
            if (results.IsValid)
            {
                _portfolioManager.TAdd(portfolio);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult DeletePortfolio(int id)
        {
            var value = _portfolioManager.TGetByID(id);
            _portfolioManager.TDelete(value);
            return RedirectToAction("Index");
        }   

        [HttpGet]
        public IActionResult EditPortfolio(int id)
        {
            ViewBag.v1 = "Proje Lİstesi ";
            ViewBag.v2 = "Projelerim ";
            ViewBag.v3 = "Proje Düzenleme ";
            var value = _portfolioManager.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditPortfolio(Portfolio portfolio)
        {
            ViewBag.v1 = "Proje Lİstesi ";
            ViewBag.v2 = "Projelerim ";
            ViewBag.v3 = "Proje Düzenleme ";
            PortfolioValidatior portfolioValidatior = new PortfolioValidatior();
            ValidationResult results = portfolioValidatior.Validate(portfolio);
            if (results.IsValid)
            {
                _portfolioManager.TUpdate(portfolio);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
