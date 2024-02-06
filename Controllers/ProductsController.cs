using Microsoft.AspNetCore.Mvc;

namespace ChushkaAssignment.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
