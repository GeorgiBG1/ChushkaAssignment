using ChushkaAssignment.Data;
using ChushkaAssignment.Data.Models;
using ChushkaAssignment.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChushkaAssignment.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<AppUser> userManager;

        public OrdersController(ApplicationDbContext db, UserManager<AppUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }
        public IActionResult All()
        {
            if (!db.Orders.Any())
            {
                var order1 = new Order
                {
                    Client = db.Users.FirstOrDefault(u => u.Email == "pesho@peshov.com")!,
                    Product = db.Products.FirstOrDefault()!,
                    OrderedOn = new DateTime(2012, 12, 21, 15, 30, 0)
                };
                var order2 = new Order
                {
                    Client = db.Users.FirstOrDefault(u => u.Email == "admin@admin.com")!,
                    Product = db.Products.OrderBy(p => p.Id).LastOrDefault()!,
                    OrderedOn = new DateTime(2012, 12, 21, 15, 30, 0)
                };
                db.Orders.Add(order1);
                db.Orders.Add(order2);
                db.SaveChanges();
            }
            var orders = db.Orders
                .Include(o => o.Client)
                .Include(o => o.Product)
                .ToList();
            var model = orders.Select(o => new OrderViewModel
            {
                Id = o.Id,
                Customer = o.Client,
                Product = o.Product,
                OrderedOn = o.OrderedOn,
            }).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Order(string id)
        {
            var product = db.Products.FirstOrDefault(p => p.Id == id);
            var userId = userManager.GetUserId(HttpContext.User);
            var user = db.Users.FirstOrDefault(u => u.Id == userId);
            var order = new Order
            {
                Product = product,
                Client = user
            };
            db.Orders.Add(order);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }

}
