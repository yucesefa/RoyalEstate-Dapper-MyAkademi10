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
        public async Task<IActionResult> GetListSearchAdvertList(int location,int category)
        {
                var valuesSearch = await _advertService.GetListSearchAdvertAsync(location, category);
                return View(valuesSearch);
        }

    }
}
