using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class FeatureStatistics : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.skills = c.Skills.Count();
            ViewBag.messageFalse = c.Messages.Where(x=>x.Status==false).Count();
            ViewBag.messageTrue = c.Messages.Where(x => x.Status == true).Count();
            ViewBag.experiences = c.Experiences.Count();
            ViewBag.lastMessageFalse = c.Messages.Where(x => x.Status == false).OrderByDescending(x=>x.MessageID).Select(y=>y.Name).FirstOrDefault();
            ViewBag.lastMessageTrue = c.Messages.Where(x => x.Status == true).OrderByDescending(x => x.MessageID).Select(y => y.Name).FirstOrDefault();
            ViewBag.lastSkill = c.Skills.OrderByDescending(x => x.SkillID).Select(y => y.Title).FirstOrDefault();
            ViewBag.lastExperience = c.Experiences.OrderByDescending(x => x.ExperienceID).Select(y => y.Name).FirstOrDefault();
            return View();
        }
    }
}
