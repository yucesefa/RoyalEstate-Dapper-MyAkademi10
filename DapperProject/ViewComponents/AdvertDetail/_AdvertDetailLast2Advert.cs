using DapperProject.Services.AdvertServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents.AdvertDetail
{
    public class _AdvertDetailLast2Advert:ViewComponent
    {
        private readonly IAdvertService _advertService;

        public _AdvertDetailLast2Advert(IAdvertService advertService)
        {
            _advertService = advertService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _advertService.GetLast2AdvertAsync();
            return View(values);
        }
    }
}
