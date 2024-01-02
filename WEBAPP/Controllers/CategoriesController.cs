using Microsoft.AspNetCore.Mvc;
using WEBAPP.Models;

namespace WEBAPP.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetCategories();
            return View(categories);
        }

        public IActionResult Edit(int? id)
        {
            /*var category = new Category { CategoryId = id.HasValue ? id.Value : 0 };*/
            if (id == null)
            {
                return NotFound();
            }
            var category = CategoriesRepository.GetCategoryById(id.HasValue ? id.Value : 0);
            return View("Edit", category);
        }
    }
}