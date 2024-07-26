using DapperProject.Dtos.AdvertDtos;
using DapperProject.Services.AdvertServices;
using DapperProject.Services.AgentServices;
using DapperProject.Services.CategoryServices;
using DapperProject.Services.LocationServices;
using DapperProject.Services.TagServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdvertController : Controller
    {
        private readonly IAdvertService _advertService;
        private readonly IAgentService _agentService;
        private readonly ITagService _tagService;
        private readonly ICategoryService _categoryService;
        private readonly ILocationService _locationService;

        public AdvertController(IAdvertService advertService, IAgentService agentService, ITagService tagService, ICategoryService categoryService, ILocationService locationService)
        {
            _advertService = advertService;
            _agentService = agentService;
            _tagService = tagService;
            _categoryService = categoryService;
            _locationService = locationService;
        }

        public async Task<IActionResult> AdvertList()
        {
            var values = await _advertService.GetResultAdvertAsync();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateAdvert()
        {
            ViewBag.TagList = await _tagService.GetAllTagAsync();
            ViewBag.AgentList = await _agentService.GetAllAgentsAsync();
            ViewBag.CategoryList = await _categoryService.GetAllCategoryAsync();
            ViewBag.LocationList = await _locationService.GetAllLocationsAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdvert(CreateAdvertDto createAdvertDto)
        {
            await _advertService.CreateAdvertAsync(createAdvertDto);
            return RedirectToAction("AdvertList", "Advert");
        }
        public async Task<IActionResult> DeleteAdvert(int id)
        {
            await _advertService.DeleteAdvertAsync(id);
            return RedirectToAction("AdvertList", "Advert");
        }
        [HttpGet]
        public async Task<IActionResult> AdvertUpdate(int id)
        {
            ViewBag.TagList = await _tagService.GetAllTagAsync();
            ViewBag.AgentList = await _agentService.GetAllAgentsAsync();
            ViewBag.CategoryList = await _categoryService.GetAllCategoryAsync();
            ViewBag.LocationList = await _locationService.GetAllLocationsAsync();
            var value = await _advertService.GetAdvertAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> AdvertUpdate(UpdateAdvertDto updateAdvertDto)
        {
            await _advertService.UpdateAdvertAsync(updateAdvertDto);
            return RedirectToAction("AdvertList", "Advert");
        }

    }
}
