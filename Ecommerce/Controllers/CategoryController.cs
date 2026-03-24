using Ecommerce.Models;
using Ecommerce.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Ecommerce.Controllers
{
    public class CategoryController(CategoryService _categoryService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CategoryVM entityVM)
        {
            ViewBag.message = null;
            if (!ModelState.IsValid) return View(entityVM);
            await _categoryService.AddAsync(entityVM);
            TempData["message"] = "Created category";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var categoryVM = await _categoryService.GetByIdAsync(id);
            return View(categoryVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryVM entityVM)
        {
            ViewBag.message = null;
            if (!ModelState.IsValid) return View(entityVM);

            await _categoryService.EditAsync(entityVM);
            TempData["message"] = "Edited category";
            return RedirectToAction("Index");
        }
    }
}