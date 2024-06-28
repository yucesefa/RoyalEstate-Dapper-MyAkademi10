using DapperProject.Services.AdvertServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents
{
    public class _Last4AdvertComponentPartial:ViewComponent
    {
        private readonly IAdvertService _advertService;

        public _Last4AdvertComponentPartial(IAdvertService advertService)
        {
            _advertService = advertService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _advertService.GetLast4AdvertAsync();
            return View(values);
        }
    }
}
