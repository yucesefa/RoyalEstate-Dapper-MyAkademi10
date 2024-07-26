using DapperProject.Services.KaggleDatasetService;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KaggleDatasetController : Controller
    {
        private readonly IDataSetService _dataSetService;

        public KaggleDatasetController(IDataSetService dataSetService)
        {
            _dataSetService = dataSetService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.AllDataCount = await _dataSetService.GellDataCountAsync();
            ViewBag.AllDataCityCount = await _dataSetService.GettAllCityCountAsync();
            ViewBag.AllDataAvgPrice=await _dataSetService.GetAllDataAvgPriceAsync();
            ViewBag.AllDataAvgBed=await _dataSetService.GettAllAvgBedAsync();
            var values = await _dataSetService.GetAllDataAsync();
            return View(values);
        }
    }
}
