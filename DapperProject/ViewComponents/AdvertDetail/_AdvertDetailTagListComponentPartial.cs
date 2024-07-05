using DapperProject.Services.TagServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents.AdvertDetail
{
    public class _AdvertDetailTagListComponentPartial:ViewComponent
    {
        private readonly ITagService _tagService;

        public _AdvertDetailTagListComponentPartial(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int tag)
        {
            var values = await _tagService.GetAllTagAsync();
            return View(values);
        }
    }
}
