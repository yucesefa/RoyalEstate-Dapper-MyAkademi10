using DapperProject.Services.AdvertServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents.AdvertDetail
{
    public class _AdvertDetailContentComponentPartial:ViewComponent
    {
        private readonly IAdvertService _advertService;

        public _AdvertDetailContentComponentPartial(IAdvertService advertService)
        {
            _advertService = advertService;
        }

        public async Task<IViewComponentResult>InvokeAsync(int id)
        {
            var values = await _advertService.GetByIdAdvertAsync(id);
            return View(values);
        }
    }
}
