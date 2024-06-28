using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents
{
    public class _OtherFeatureComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
