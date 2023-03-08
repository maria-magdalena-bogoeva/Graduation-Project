using BulgariaApp.Abstraction;
using BulgariaApp.Models.Attraction;
using BulgariaApp.Models.Excursion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulgariaApp.Controllers
{
    public class ExcursionContoller : Controller
    {
        private readonly IExcursionService _excursionService;
        private readonly IAttractionService _attractionService;
        // GET: ExcursionContoller
        public ExcursionContoller(IExcursionService excursionService, IAttractionService attractionService)
        {
            this._excursionService = excursionService;
            this._attractionService = attractionService;
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: ExcursionContoller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExcursionContoller/Create
       
        public IActionResult Create()
        {
            //var excursion = new ExcursionCreateVM();

            //excursion.Attractions = _attractionService.GetAttractions()
            //    .Select(x => new AttractionPairVM()
            //    {
            //        Id = x.Id,
            //        Name = x.AttractionName
            //    }).ToList();

            return View();
            
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(ExcursionCreateVM bindingModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var created = _excursionService.Create(bindingModel.ExcurionName, bindingModel.Description, bindingModel.Picture, bindingModel.AttractionId, bindingModel.MaxVisitors, bindingModel.Price, bindingModel.Discount);
        //        if (created)
        //        {
        //            return this.RedirectToAction("Index");
        //        }

        //    }
        //    return this.View();
        //}
       // POST: ExcursionContoller/Create
       [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] ExcursionCreateVM excursion)
        {
            if (ModelState.IsValid)
            {
                var createdId = _excursionService.Create(excursion.ExcurionName, excursion.Description,
                   excursion.Picture, excursion.AttractionId,
                   excursion.MaxVisitors, excursion.Price, excursion.Discount);
                if (createdId)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }

        // GET: ExcursionContoller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExcursionContoller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExcursionContoller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExcursionContoller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
