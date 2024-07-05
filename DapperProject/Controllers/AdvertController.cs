using DapperProject.Services.AdvertServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
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

        public async Task<IActionResult> AdvertList( int page=1)
        {
            var values = await _advertService.GetResultAdvertAsync();  
            return View(values.ToPagedList(page,6));
        }
        public async Task<IActionResult>GetListSearchAdvertList(string word, int location, float minPrice, int category, float maxPrice)
        {
            if (!string.IsNullOrEmpty(word) || location > 0 || category > 0 || minPrice > 0 || maxPrice > 0)
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
                var valuesSearch = await _advertService.GetListSearchAdvertAsync(word, location, minPrice, maxPrice, category);
                return View(valuesSearch);
            }
            //var values = await _advertService.GetResultAdvertAsync();
            return View(/*values*/);
        }

    }
}
