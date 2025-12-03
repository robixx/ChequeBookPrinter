using Microsoft.AspNetCore.Mvc;

namespace CheckBookPrinter.Areas.Dashboard.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
