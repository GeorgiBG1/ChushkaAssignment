using Microsoft.AspNetCore.Mvc;

namespace ChushkaAssignment.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
