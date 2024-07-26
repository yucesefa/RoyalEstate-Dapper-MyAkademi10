using DapperProject.Dtos.TagDtos;
using DapperProject.Services.TagServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task<IActionResult> TagList()
        {
            var values = await _tagService.GetAllTagAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateTag()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag(CreateTagDto createTagDto)
        {
            await _tagService.CreateTagAsync(createTagDto);
            return RedirectToAction("TagList");
        }

        public async Task<IActionResult> DeleteTag(int id)
        {
            await _tagService.DeleteTagAsync(id);
            return RedirectToAction("TagList");
        }
        public async Task<IActionResult> UpdateTag(int id)
        {
            var value = await _tagService.GetTagAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTag(UpdateTagDto updateTagDto)
        {
            await _tagService.UpdateTagAsync(updateTagDto);
            return RedirectToAction("TagList");
        }
    }
}
