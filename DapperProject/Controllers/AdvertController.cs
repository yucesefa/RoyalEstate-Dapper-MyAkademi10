using DapperProject.Services.AdvertServices;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace DapperProject.Controllers
{
    public class AdvertController : Controller
    {
        private readonly IAdvertService _advertService;

        public AdvertController(IAdvertService advertService)
        {
            _advertService = advertService;
        }

        public async Task<IActionResult> AdvertList(string word, int location,float minPrice, float maxPrice,int page=1)
        {
            if (!string.IsNullOrEmpty(word) || location > 0 || minPrice > 0 || maxPrice > 0)
            {
                if (word == null)
                {
                    word = "";
                }
                if (minPrice == 0)
                {
                    minPrice = await _advertService.GetMinPrice();
                }
                if (maxPrice == 0)
                {
                    maxPrice = await _advertService.GetMaxPrice();
                }
                var valuesSearch = await _advertService.GetListSearchAdvertAsync(word, location, minPrice, maxPrice);
                return View(valuesSearch);
            }
            var values = await _advertService.GetResultAdvertAsync();
            return View(values.ToPagedList(page,3));
        }
       
    }
}
