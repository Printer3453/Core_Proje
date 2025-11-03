

using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class MessageList : ViewComponent
    {
        UserMessageManager _userMessageManager = new UserMessageManager(new EfUserMessageDal());
        public IViewComponentResult Invoke()
        {
            var values = _userMessageManager.GetUserMessagesWithUserService()
                .OrderByDescending(x => x.Date)
                .Take(5)
                .ToList();

            return View(values);
        }




    }
}
