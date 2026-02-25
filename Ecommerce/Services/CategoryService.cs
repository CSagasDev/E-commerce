using Ecommerce.Entities;
using Ecommerce.Models;
using Ecommerce.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Services
{
    public class CategoryService(GenericRepository<Category>_categoryRepository)
    {
        public async Task<IEnumerable<CategoryVM>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();

            var categoriesVM = categories.Select(item =>
            new CategoryVM
            {
                CategoryId = item.CategoryId,
                Name = item.Name,
            }).ToList();

            return categoriesVM;
        }
    }
}
