using BusinessLayer.Concrete;
using Core_Proje.Areas.Writer.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using System.Xml.Linq;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class DashboardController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;
        WeatherApiManager _weatherApi = new WeatherApiManager(new EfWeatherApiDal());

        public DashboardController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = values.Name + " " + values.SurName;

            //Weather Api
            var apiEntity = _weatherApi.TGetByID(1);
            string url = apiEntity.connection?.Trim() ?? "";
            string api = apiEntity.api?.Trim() ?? "";

            string connection = url + api;

            XDocument documant = XDocument.Load(connection);


            //statistics
            Context c = new Context();
            ViewBag.v1 = c.WriterMessages.Where(x => x.Receiver == values.Email).Count();
            ViewBag.v2 = c.Announcements.Count();
            ViewBag.v3 = c.Users.Count();
            ViewBag.v4 = c.Skills.Count();
            ViewBag.v5 = documant.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            return View();
        }
    }
}
// {API key}