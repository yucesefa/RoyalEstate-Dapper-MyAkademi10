using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents.UILayout
{
	public class _ScriptComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
