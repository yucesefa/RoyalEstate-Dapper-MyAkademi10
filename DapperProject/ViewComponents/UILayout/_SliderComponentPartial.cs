using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents.UILayout
{
	public class _SliderComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
