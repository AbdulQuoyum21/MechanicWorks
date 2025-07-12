using Microsoft.AspNetCore.Mvc;

namespace Mechanic.API.Controllers
{
    public class CustomerController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
