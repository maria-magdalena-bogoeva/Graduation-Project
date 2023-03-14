using BulgariaApp.Abstraction;
using BulgariaApp.Models.Statistics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulgariaApp.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IStatisticsService _statisticsService;
        public StatisticsController(IStatisticsService statisticsService)
        {
            this._statisticsService = statisticsService;
        }
        // GET: StatisticsController
        public ActionResult Index()
        {
            StatisticsVM statistics = new StatisticsVM();

            statistics.CountClients = _statisticsService.CountClients();
            statistics.CountProducts = _statisticsService.CountProducts();
            statistics.CountOrders = _statisticsService.CountOrders();
            statistics.SumOrders = _statisticsService.SumOrders();

            return View(statistics);
        }

        
    }
}
