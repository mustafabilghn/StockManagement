using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.ProjectModel;
using StockManagement.Data;
using StockManagement.Models;

namespace StockManagement.Controllers
{
    public class CategoryController : Controller
    {
        private AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        public IActionResult Edit(int id)
        {
            var item = _context.Categories.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        public IActionResult Edit([Bind("Id,Name")] Category category)
        {
            bool isExist = _context.Categories.Any(a => a.Name.ToLower() == category.Name.ToLower());

            if (isExist)
            {
                ModelState.AddModelError("Name", "Eklemeye çalıştığınız kategori sistemde mevcut!");
                return View(category);
            }

            var ctg = _context.Categories.FirstOrDefault(c => c.Id == category.Id);

            if (ctg == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(category);
            }

            ctg.Name = category.Name;

            _context.Categories.Update(ctg);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            bool isExist = _context.Categories.Any(a => a.Name.ToLower() == category.Name.ToLower());

            if (isExist)
            {
                ModelState.AddModelError("Name", "Eklemeye çalıştığınız kategori sistemde mevcut!");
                return View(category);
            }

            if (!ModelState.IsValid)
            {
                return View(category);
            }

            category = new Category
            {
                Name = category.Name
            };

            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var item = _context.Categories.FirstOrDefault(c => c.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            var item = _context.Categories.FirstOrDefault(c=>c.Id == category.Id);

            if (item == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(item);
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}
