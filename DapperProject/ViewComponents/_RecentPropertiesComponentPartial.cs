using DapperProject.Services.AdvertServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents
{
    public class _RecentPropertiesComponentPartial:ViewComponent
    {
        private readonly IAdvertService _advertService;

        public _RecentPropertiesComponentPartial(IAdvertService advertService)
        {
            _advertService = advertService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _advertService.GetLast6AdvertAsync();
            return View(values);
        }
    }
}
