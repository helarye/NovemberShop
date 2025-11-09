using Microsoft.AspNetCore.Mvc;
using NovemberShop.Data;
using NovemberShop.Models;

namespace NovemberShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult IndexPr()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        // GET: Product/EditPr/5
        [HttpGet]
        public IActionResult EditPr(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Product/EditPr/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPr(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var existingProduct = _context.Products.Find(product.Id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.ImageUrl = product.ImageUrl;

            _context.SaveChanges();
            return RedirectToAction("IndexPr");
        }
    }
}
