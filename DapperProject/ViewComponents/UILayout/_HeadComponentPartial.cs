using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents.UILayout
{
	public class _HeadComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
