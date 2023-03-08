using BulgariaApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulgariaApp.Abstraction
{
   public interface IAttractionService
    {
        bool Create(string name, string picture, string description, int categoryId);
        bool Update(int attractionId, string name, string picture, string description, int categoryId);
      
        List<Attraction> GetAttractions();
        Attraction GetAttractionById(int attractionId);
        bool RemoveById(int attractionId);
        List<Attraction> GetAttractions(string searchStringCategoryName);
    }
}
