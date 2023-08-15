using Microsoft.AspNetCore.Mvc;

namespace OnlineCarMarket.Areas.Administrator.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
