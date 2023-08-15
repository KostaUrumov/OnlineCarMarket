using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineCarMarket.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Route("/Administrator/[controller]/[Action]/{id?}")]
    [Authorize(Policy = "AdminsOnly")]
    public class BaseController : Controller
    {
        
    }
}
