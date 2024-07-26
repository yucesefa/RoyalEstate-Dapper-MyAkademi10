using DapperProject.Services.AdvertServices;
using DapperProject.Services.CategoryServices;
using DapperProject.Services.LocationServices;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace DapperProject.ViewComponents.UILayout
{
	public class _SearchPropertyComponentPartial:ViewComponent
	{
		private readonly ILocationService _locationService;
		private readonly ICategoryService _categoryService;
		private readonly IAdvertService _advertService;

        public _SearchPropertyComponentPartial(ILocationService locationService, ICategoryService categoryService, IAdvertService advertService)
        {
            _locationService = locationService;
            _categoryService = categoryService;
            _advertService = advertService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
		{
			var values= await _locationService.GetAllLocationsAsync();
			ViewBag.category = await _categoryService.GetAllCategoryAsync();
			return View(values);
		}
	}
}
