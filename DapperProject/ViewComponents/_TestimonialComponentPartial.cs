using DapperProject.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents
{
	public class _TestimonialComponentPartial:ViewComponent
	{
		private readonly ITestimonialService _testimonialService;

		public _TestimonialComponentPartial(ITestimonialService testimonialService)
		{
			_testimonialService = testimonialService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _testimonialService.GetAllTestimonialAsync();
			return View(values);
		}
	}
}
