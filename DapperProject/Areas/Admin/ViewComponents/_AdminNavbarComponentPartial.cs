using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Areas.Admin.ViewComponents
{
    public class _AdminNavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
