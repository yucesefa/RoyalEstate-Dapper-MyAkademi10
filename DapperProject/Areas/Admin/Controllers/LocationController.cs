using DapperProject.Dtos.LocationDtos;
using DapperProject.Services.LocationServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public async Task<IActionResult> LocationList()
        {
            var values = await _locationService.GetAllLocationsAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateLocation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationDto createLocationDto)
        {
            await _locationService.CreateLocationAsync(createLocationDto);
            return RedirectToAction("LocationList");
        }

        public async Task<IActionResult> DeleteLocation(int id)
        {
            await _locationService.DeleteLocationAsync(id);
            return RedirectToAction("LocationList");
        }
        public async Task<IActionResult> UpdateLocation(int id)
        {
            var value = await _locationService.GetLocationAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLocation(UpdateLocationDto updateLocationDto)
        {
            await _locationService.UpdateLocationAsync(updateLocationDto);
            return RedirectToAction("LocationList");
        }
    }
}
