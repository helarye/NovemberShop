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
        // GET: Product/CreatePr
        [HttpGet]
        public IActionResult CreatePr()
        {
            return View();
        }

        // POST: Product/CreatePr
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePr(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("IndexPr");
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
        // GET: Product/DeletePr/5
        public IActionResult DeletePr(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("IndexPr");
        }
    }
}
