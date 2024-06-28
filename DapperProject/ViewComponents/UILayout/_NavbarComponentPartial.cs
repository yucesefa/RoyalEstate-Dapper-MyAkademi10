using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents.UILayout
{
	public class _NavbarComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
