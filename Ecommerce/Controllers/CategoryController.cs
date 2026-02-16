using Ecommerce.Context;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class CategoryController(AppDbContext _dbContext) : Controller
    {
        public IActionResult Index()
        {
            var categories = _dbContext.Category.Select(item =>
            new CategoryVM
            {
                CategoryId = item.CategoryId,
                Name = item.Name,
            }).ToList();
            return View(categories);
        }
    }
}