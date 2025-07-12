using Microsoft.AspNetCore.Mvc;

namespace Mechanic.API.Controllers
{
    public class InvoiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
