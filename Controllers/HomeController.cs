using ChushkaAssignment.Data;
using ChushkaAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ChushkaAssignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult Index()
        {
            var products = db.Products.OrderBy(p => p.Name).ToList();
            var model = new List<ProductViewModel>();
            for (int i = 0; i < products.Count(); i++)
            {
                if (products[i].Description.Length > 50)
                {
                    products[i].Description = products[i].Description[..50] + "...";
                }
                var productViewModel = new ProductViewModel
                {
                    Id = products[i].Id,
                    Name = products[i].Name,
                    Price = products[i].Price,
                    Description = products[i].Description,
                };
                model.Add(productViewModel);
            }
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}