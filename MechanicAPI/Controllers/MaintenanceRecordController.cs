using Microsoft.AspNetCore.Mvc;

namespace Mechanic.API.Controllers
{
    public class MaintenanceRecordController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
