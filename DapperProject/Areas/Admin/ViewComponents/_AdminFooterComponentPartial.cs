using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Areas.Admin.ViewComponents
{
    public class _AdminFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
