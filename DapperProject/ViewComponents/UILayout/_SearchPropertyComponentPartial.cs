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
		private readonly IAdvertService _advertService;
		private readonly ICategoryService _categoryService;

        public _SearchPropertyComponentPartial(ILocationService locationService, IAdvertService advertService, ICategoryService categoryService)
        {
            _locationService = locationService;
            _advertService = advertService;
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _locationService.GetAllLocationsAsync();	
			var minPrice = await _advertService.GetMinPrice();
			var maxPrice = await _advertService.GetMaxPrice();
			var categories = await _categoryService.GetAllCategoryAsync();


			var fark = maxPrice - minPrice;
			var kademe = fark / 10;

			List<float> minPrices = new List<float>();
			minPrices.Add(minPrice);
			for (int i = 0; i < 4; i++)
			{
				minPrice += kademe;
				minPrices.Add(minPrice);
			}

			List<float> maxPrices = new List<float>();
			maxPrices.Add(maxPrice);
			for (int i = 0; i < 4; i++)
			{
				maxPrice -= kademe;
				maxPrices.Add(maxPrice);
			}

			ViewBag.minPrice = minPrices;
			ViewBag.maxPrice = maxPrices;
			ViewData["Categories"] = categories.ToList();

			return View(values);
		}
	}
}
