using BulgariaApp.Abstraction;
using BulgariaApp.Data;
using BulgariaApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulgariaApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Category> GetCategories()
        {
            List<Category> categories = _context.Categories.ToList();
            return categories;
        }

        public Category GetCategoryById(int categoryId)
        {
            return _context.Categories.Find(categoryId);
        }
       
        public List<Attraction> GetAttractionsByCategory(int categoryId)
        {
            return _context.Attractions.Where(x => x.CategoryId == categoryId).ToList();
        }
    }
}
