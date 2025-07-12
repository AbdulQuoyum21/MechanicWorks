using Microsoft.AspNetCore.Mvc;

namespace Mechanic.API.Controllers
{
    public class VehicleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
