using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents.UILayout
{
	public class _FooterComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
