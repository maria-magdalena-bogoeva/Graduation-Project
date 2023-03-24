using BulgariaApp.Abstraction;
using BulgariaApp.Entities;
using BulgariaApp.Models.Attraction;
using BulgariaApp.Models.Excursion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulgariaApp.Controllers
{
    [Authorize(Roles="Administrator")]
    public class ExcursionController : Controller
    {
        private readonly IExcursionService _excursionService;
        private readonly IAttractionService _attractionService;

        // GET: ExcursionContoller
        public ExcursionController(IExcursionService excursionService, IAttractionService attractionService)
        {
            this._excursionService = excursionService;
            this._attractionService = attractionService;

        }
        [AllowAnonymous]
        public ActionResult Index(string searchStringExcursionName, string searchPrice)
        {
            List<ExcursionIndexVM> excursions = _excursionService.GetExcursions(searchStringExcursionName, searchPrice)
            .Select(excursion => new ExcursionIndexVM
            {
                Id = excursion.Id,
                ExcurionName = excursion.ExcurionName,
                StartDate = excursion.StartDate,
                EndDate = excursion.EndDate,
                Description = excursion.Description,
                Picture = excursion.Picture,
                Picture1 = excursion.Picture1,
                Picture2 = excursion.Picture2,
                Picture3 = excursion.Picture3,
                Picture4 = excursion.Picture4,
                AttractionId = excursion.AttractionId,
                AttractionName = excursion.Attraction.AttractionName,
                MaxVisitors = excursion.MaxVisitors,
                Price = excursion.Price,
                Discount = excursion.Discount

            }).ToList();
            return this.View(excursions);
        }
        [AllowAnonymous]
        // GET: ExcursionContoller/Details/5
        public ActionResult Details(int id)
        {
            Excursion item = _excursionService.GetExcursionById(id);
            if (item==null)
            {
                return NotFound();
            }

            ExcursionDetailsVM excursion = new ExcursionDetailsVM()
            {
                Id = item.Id,
                ExcurionName = item.ExcurionName,
                StartDate = item.StartDate,
                EndDate = item.EndDate,
                Description = item.Description,
                Picture = item.Picture,
                Picture1 = item.Picture1,
                Picture2 = item.Picture2,
                Picture3 = item.Picture3,
                Picture4 = item.Picture4,
                AttractionId = item.AttractionId,
                AttractionName = item.Attraction.AttractionName,
                MaxVisitors = item.MaxVisitors,
                Price = item.Price,
                Discount = item.Discount
            };
            return View(excursion);
        }

        // GET: ExcursionContoller/Create

        public IActionResult Create()
        {

            var excursion = new ExcursionCreateVM();


            excursion.Attractions = _attractionService.GetAttractions()
                .Select(x => new AttractionPairVM()
                {
                    Id = x.Id,
                    Name = x.AttractionName
                }).ToList();

            return View(excursion);

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
                var createdId = _excursionService.Create(excursion.ExcurionName, excursion.StartDate, excursion.EndDate, excursion.Description,
                   excursion.Picture, excursion.Picture1, excursion.Picture2, excursion.Picture3, excursion.Picture4, excursion.AttractionId,
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
            Excursion excursion = _excursionService.GetExcursionById(id);
            if (excursion == null)
            {
                return NotFound();
            }

            ExcursionEditVM updatedExcursion = new ExcursionEditVM()
            {
                Id = excursion.Id,
                ExcurionName = excursion.ExcurionName,
                StartDate = excursion.StartDate,
                EndDate = excursion.EndDate,
                Description = excursion.Description,
                Picture = excursion.Picture,
                Picture1 = excursion.Picture1,
                Picture2 = excursion.Picture2,
                Picture3 = excursion.Picture3,
                Picture4 = excursion.Picture4,
                AttractionId = excursion.AttractionId,
                MaxVisitors = excursion.MaxVisitors,
                Price = excursion.Price,
                Discount = excursion.Discount
            };
            updatedExcursion.Attractions = _attractionService.GetAttractions()
                .Select(x => new AttractionPairVM()
                {
                    Id = x.Id,
                    Name = x.AttractionName
                }
                ).ToList();


            return this.View(updatedExcursion);
        }

        // POST: ExcursionContoller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ExcursionEditVM excursion)
        {
            
            if (ModelState.IsValid)
            {
                var updated = _excursionService.Update(id,excursion.ExcurionName, excursion.StartDate, excursion.EndDate, excursion.Description,
                   excursion.Picture, excursion.Picture1, excursion.Picture2, excursion.Picture3, excursion.Picture4, excursion.AttractionId,
                   excursion.MaxVisitors, excursion.Price, excursion.Discount);
                if (updated)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
            
        }

        // GET: ExcursionContoller/Delete/5
        public ActionResult Delete(int id)
        {
            Excursion item = _excursionService.GetExcursionById(id);
            if (item == null)
            {
                return NotFound();
            }
            ExcursionDeleteVM excursion = new ExcursionDeleteVM()
            {
                Id = item.Id,
                ExcurionName = item.ExcurionName,
                StartDate = item.StartDate,
                EndDate = item.EndDate,
                Description = item.Description,
                Picture = item.Picture,
                Picture1 = item.Picture1,
                Picture2 = item.Picture2,
                Picture3 = item.Picture3,
                Picture4 = item.Picture4,
                AttractionId = item.AttractionId,
                AttractionName = item.Attraction.AttractionName,
                MaxVisitors = item.MaxVisitors,
                Price = item.Price,
                Discount = item.Discount


            };
            return View(excursion);
        }

        // POST: AttractionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var deleted = _excursionService.RemoveById(id);

            if (deleted)
            {
                return this.RedirectToAction("Success");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Success()
        {

            return View();
        }
    }
}
