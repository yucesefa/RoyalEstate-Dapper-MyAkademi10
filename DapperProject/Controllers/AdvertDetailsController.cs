using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Controllers
{
    public class AdvertDetailsController : Controller
    {
        public IActionResult Index(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
