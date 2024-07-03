using DapperProject.Services.AdvertServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents.AdvertDetail
{
    public class _AdvertDetailCategoryListComponentPartial:ViewComponent
    {
        private readonly IAdvertService _advertService;

        public _AdvertDetailCategoryListComponentPartial(IAdvertService advertService)
        {
            _advertService = advertService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _advertService.GetAdvertDetailCategoryCountsAsync();
            return View(values);
        }
    }
}
