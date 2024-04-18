using Microsoft.AspNetCore.Mvc;
using SupermarcheInventoryManagement.Data;
using SupermarcheInventoryManagement.Models;

namespace SupermarcheInventoryManagement.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
           _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> objCategoriesList = _context.Products.ToList();
            return View(objCategoriesList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product p)
        {
            if (p.BrandName == p.ProductName)
            {
                ModelState.AddModelError("name", "The brand name cannot be same as product name");
            }
            if (ModelState.IsValid)
            {
                _context.Products.Add(p);
                _context.SaveChanges();
                TempData["success"] = "Product registered successfully";
                return RedirectToAction("Index");
            }
            return View(p);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var categoryFromDb = _context.Products.Find(id);
            var categoryFromDbFirst=_context.Products.FirstOrDefault(u => u.Id == id);
            var categoryFromDbSingle=_context.Products.SingleOrDefault(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product p)
        {
            if (p.BrandName == p.ProductName)
            {
                ModelState.AddModelError("name", "The brand name cannot be same as product name");
            }
            if (ModelState.IsValid)
            {
                _context.Update(p);
                _context.SaveChanges();
                TempData["success"] = "Product details updated successfully";
                return RedirectToAction("Index");
            }
            return View(p);
        }
        public IActionResult Delete(int id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb= _context.Products.Find(id);
            if(categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var c= _context.Products.Find(id);
            if (c==null)
            {
                return NotFound();
            }
            _context.Remove(c);
            _context.SaveChanges();
            TempData["success"] = "Product details removed successfully";
            return RedirectToAction("Index");
        }
    }
}
