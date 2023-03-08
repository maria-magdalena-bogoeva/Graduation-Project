using BulgariaApp.Abstraction;
using BulgariaApp.Data;
using BulgariaApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulgariaApp.Services
{
    public class AttractionService : IAttractionService
    {
        private readonly ApplicationDbContext _context;
        public AttractionService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Create(string name, string picture, string description, int categoryId)
        {
            Attraction attraction = new Attraction
            {
                AttractionName = name,
                Description = description,
                Picture = picture,
                Category = _context.Categories.Find(categoryId),
              
            };
            _context.Attractions.Add(attraction);
            return _context.SaveChanges() != 0;
        }

        public Attraction GetAttractionById(int attractionId)
        {
            return _context.Attractions.Find(attractionId);
        }

        public List<Attraction> GetAttractions()
        {
            List<Attraction> attractions = _context.Attractions.ToList();
            return attractions;
        }

        public List<Attraction> GetAttractions(string searchStringCategoryName)
        {
            List<Attraction> attractions = _context.Attractions.ToList();
            if (!String.IsNullOrEmpty(searchStringCategoryName) )
            {
                attractions = attractions.Where(x => x.Category.CategoryName.ToLower().Contains(searchStringCategoryName.ToLower())
               ).ToList();
            }
            
            return attractions;
          
        }

        public bool RemoveById(int attractionId)
        {
            var attraction = GetAttractionById(attractionId);
            if (attraction == default(Attraction))
            {
                return false;
            }
            _context.Remove(attraction);
            return _context.SaveChanges() != 0;
        }

        public bool Update(int attractionId, string name, string picture, string description, int categoryId)
        {
            var attraction = GetAttractionById(attractionId);
            if (attraction == default(Attraction))
            {
                return false;
            }

            attraction.AttractionName = name;
            attraction.Picture = picture;
            attraction.Description = description;


            attraction.Category = _context.Categories.Find(categoryId);
            attraction.Picture = picture;
            attraction.Description = description;


            _context.Update(attraction);
            return _context.SaveChanges() != 0;
        }
    }
}
