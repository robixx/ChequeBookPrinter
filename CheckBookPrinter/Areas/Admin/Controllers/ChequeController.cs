using Microsoft.AspNetCore.Mvc;

namespace CheckBookPrinter.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChequeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
