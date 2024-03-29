﻿using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Create()
        {
            return View("Create");
        }

        //Store to DB
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Store(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.AddCategory(category);
                return RedirectToAction("Index");
            }
            return View("Create", category);
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

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.UpdateCategory(category.CategoryId, category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Delete(int id)
        {
            CategoriesRepository.DeleteCategory(id);

            return RedirectToAction("Index");
        }
    }
}