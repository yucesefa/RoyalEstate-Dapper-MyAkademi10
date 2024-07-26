using DapperProject.Services.AdvertServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents.UILayout
{
    public class _SliderComponentPartial:ViewComponent
	{
		private readonly IAdvertService _advertService;

        public _SliderComponentPartial(IAdvertService advertService)
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
