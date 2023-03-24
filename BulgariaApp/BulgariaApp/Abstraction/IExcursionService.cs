using BulgariaApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulgariaApp.Abstraction
{
    public interface IExcursionService
    {
        bool Create(string name, DateTime startDate, DateTime endDate, string description, string picture, string picture1, string picture2, string picture3, string picture4, int attractionId, int maxVisitors, decimal price, decimal discount);
        bool Update(int excursionId, string name, DateTime startDate, DateTime endDate, string description, string picture, string picture1, string picture2, string picture3, string picture4, int attractionId, int maxVisitors, decimal price, decimal discount);

        List<Excursion> GetExcursions();

        Excursion GetExcursionById(int excursionId);

        bool RemoveById(int excursionId);

        List<Excursion> GetExcursions(string searchStringExcursionName, string searchPrice);
    }
}
