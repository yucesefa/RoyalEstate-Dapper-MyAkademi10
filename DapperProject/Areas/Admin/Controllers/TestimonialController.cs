using DapperProject.Dtos.TestimonialDtos;
using DapperProject.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _tagService;

        public TestimonialController(ITestimonialService tagService)
        {
            _tagService = tagService;
        }

        public async Task<IActionResult> TestimonialList()
        {
            var values = await _tagService.GetAllTestimonialAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            await _tagService.CreateTestimonialAsync(createTestimonialDto);
            return RedirectToAction("TestimonialList");
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _tagService.DeleteTestimonialAsync(id);
            return RedirectToAction("TestimonialList");
        }
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var value = await _tagService.GetTestimonialAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            await _tagService.UpdateTestimonialAsync(updateTestimonialDto);
            return RedirectToAction("TestimonialList");
        }
    }
}
