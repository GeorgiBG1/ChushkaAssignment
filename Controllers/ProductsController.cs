using ChushkaAssignment.Data;
using ChushkaAssignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChushkaAssignment.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext db;

        public ProductsController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Details(string id)
        {
            var product = db.Products.SingleOrDefault(p => p.Id == id);
            var model = new ProductViewModel
            {
                Id = product!.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Type = product.Type,
            };
            return View(model);
        }
        public IActionResult Create()
        {

            return View();
        }        
        public IActionResult Edit()
        {
            return View();
        }        
        public IActionResult Delete()
        {
            return View();
        }
    }
}
