using BulgariaApp.Abstraction;
using BulgariaApp.Data;
using BulgariaApp.Entities;
using BulgariaApp.Models.Excursion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulgariaApp.Services
{
    public class ExcursionService : IExcursionService
    {
        private readonly ApplicationDbContext _context;
        public ExcursionService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Create(string name, DateTime startDate, DateTime endDate, string description, string picture, int attractionId, int maxVisitors, decimal price, decimal discount)
        {
            Excursion excursion = new Excursion
            {
                ExcurionName = name,
                StartDate = startDate,
                EndDate = endDate,
                Description = description,
                Picture = picture,
                Attraction = _context.Attractions.Find(attractionId),
                MaxVisitors = maxVisitors,
                Price = price,
                Discount = discount
            };
            _context.Excursions.Add(excursion);
            return _context.SaveChanges() != 0;
        }

        public Excursion GetExcursionById(int excursionId)
        {
            return _context.Excursions.Find(excursionId);
        }

        public List<Excursion> GetExcursions()
        {
            List<Excursion> excursions = _context.Excursions.ToList();
            return excursions;
        }



        public List<Excursion> GetExcursions(string searchStringExcursionName, string searchPrice)
        {

            List<Excursion> excursions = _context.Excursions.ToList();
            if (!String.IsNullOrEmpty(searchStringExcursionName) && !String.IsNullOrEmpty(searchPrice))
            {
                excursions = excursions.Where(x => x.ExcurionName.ToLower()
                == searchStringExcursionName.ToLower() && x.Price == decimal.Parse(searchPrice)).ToList();

            }
            else if (!String.IsNullOrEmpty(searchStringExcursionName))
            {
                excursions = excursions.Where(x => x.ExcurionName.ToLower() == searchStringExcursionName.ToLower()).ToList();
            }
            else if (!String.IsNullOrEmpty(searchPrice))
            {
                excursions = excursions.Where(x => x.Price == decimal.Parse(searchPrice)).ToList();
            }

            return excursions;

        }


        public bool RemoveById(int excursionId)
        {
            var excursion = GetExcursionById(excursionId);
            if (excursion == default(Excursion))
            {
                return false;
            }
            _context.Remove(excursion);
            return _context.SaveChanges() != 0;
        }

        public bool Update(int excursionId, string name, DateTime startDate, DateTime endDate, string description, string picture, int attractionId, int maxVisitors, decimal price, decimal discount)
        {
            var excursion = GetExcursionById(excursionId);
            if (excursion == default(Excursion))
            {
                return false;
            }

            excursion.ExcurionName = name;
            excursion.StartDate = startDate;
            excursion.EndDate = endDate;
            excursion.Description = description;
            excursion.Picture = picture;
            excursion.AttractionId = attractionId;
            excursion.MaxVisitors = maxVisitors;
            excursion.Price = price;
            excursion.Discount = discount;



            excursion.Attraction = _context.Attractions.Find(attractionId);
            excursion.StartDate = startDate;
            excursion.EndDate = endDate;
            excursion.Description = description;
            excursion.Picture = picture;
            excursion.MaxVisitors = maxVisitors;
            excursion.Price = price;
            excursion.Discount = discount;


            _context.Update(excursion);
            return _context.SaveChanges() != 0;
        }
    }
}
