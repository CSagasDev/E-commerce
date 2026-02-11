using Ecommerce.Context;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class CategoryController(AppDbContext _dbContext) : Controller
    {
        public IActionResult Index()
        {
            var categories = _dbContext.Category.ToList();
            return View(categories);
        }
    }
}