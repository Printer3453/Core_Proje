using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class ToDoListPanel: ViewComponent
    {
        ToDoListManager _toDoListManager= new ToDoListManager(new EfToDoListDal());
        public IViewComponentResult Invoke()
        {
            //son 5 yapılacak işi listeleme
            var values = _toDoListManager.TGetList().OrderByDescending(x=>x.ToDoListID).Take(5).ToList();
            return View(values);
        }
    }
}
