using DapperProject.Services.AdvertServices;
using DapperProject.Services.AgentServices;
using DapperProject.Services.LocationServices;
using DapperProject.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents
{
    public class _UIStatisticsComponentPartial : ViewComponent
    {
        private readonly IAdvertService _advertService;
        private readonly IAgentService _agentService;
        private readonly ILocationService _locationService;
        private readonly ITestimonialService _testimonialService;

		public _UIStatisticsComponentPartial(IAdvertService advertService, IAgentService agentService, ILocationService locationService, ITestimonialService testimonialService)
		{
			_advertService = advertService;
			_agentService = agentService;
			_locationService = locationService;
			_testimonialService = testimonialService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.Advert = await _advertService.GetAdvertCount();
            ViewBag.Agent = await _agentService.GetAllAgentCountAsync();
            ViewBag.Location = await _locationService.GetAllLocationCountAsync();
            ViewBag.Testimonial=await _testimonialService.GetAllTestimonialCountAsync();
            return View();
        }
    }
}
