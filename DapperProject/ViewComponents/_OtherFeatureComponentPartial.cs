using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents
{
    public class _OtherFeatureComponentPartial:ViewComponent
    {
        public async Task <IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
