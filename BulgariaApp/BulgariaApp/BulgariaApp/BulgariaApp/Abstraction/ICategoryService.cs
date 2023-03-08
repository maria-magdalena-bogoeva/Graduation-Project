using BulgariaApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulgariaApp.Abstraction
{
   public interface ICategoryService
    {
        List<Category> GetCategories();
        Category GetCategoryById(int categoryId);
       
        List<Attraction> GetAttractionsByCategory(int categoryId);
    }
}
