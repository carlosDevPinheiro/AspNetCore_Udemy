using System.Linq;
using Microsoft.AspNetCore.Mvc;
using module4.Data;
using module4.Domain;

namespace module4.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext contenxt)
        {
            _context = contenxt;
        }

        public IActionResult Index(int id)
        {
            var categories = _context.Categories.ToList();
            var categorySelected = _context.Categories.FirstOrDefault(c => c.Id == id);

            ViewBag.Categories = categories;

            return View(categorySelected);
        }

        [HttpPost]
        public IActionResult Register(Category category)
        {
            if (category.Id == 0)
            {
                _context.Categories.Add(category);
            }
            else
            {
                var categorySaved = _context.Categories.FirstOrDefault(c => c.Id == category.Id);
                categorySaved.Name = category.Name;
                _context.Update(categorySaved);
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var categorySaved = _context.Categories.FirstOrDefault(c => c.Id == id);
            _context.Categories.Remove(categorySaved);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}