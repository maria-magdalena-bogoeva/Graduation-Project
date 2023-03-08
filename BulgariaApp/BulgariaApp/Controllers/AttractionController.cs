using BulgariaApp.Abstraction;
using BulgariaApp.Entities;
using BulgariaApp.Models.Attraction;
using BulgariaApp.Models.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulgariaApp.Controllers
{
    public class AttractionController : Controller
    {
        private readonly IAttractionService _attractionService;
        private readonly ICategoryService _categoryService;

        public AttractionController(IAttractionService attractionService, ICategoryService categoryService)
        {
            this._attractionService = attractionService;
            this._categoryService = categoryService;
        }
        // GET: AttractionController
        public ActionResult Index(string searchStringCategoryName)
        {
            List<AttractionIndexVM> attractions = _attractionService.GetAttractions(searchStringCategoryName)
            .Select(attraction => new AttractionIndexVM
            {
                Id = attraction.Id,
                AttractionName = attraction.AttractionName,
                CategoryId = attraction.CategoryId,
                CategoryName = attraction.Category.CategoryName,
                Picture = attraction.Picture,
                Description = attraction.Description
               

            }).ToList();
            return this.View(attractions);

        }

        // GET: AttractionController/Details/5
        public ActionResult Details(int id)
        {
            Attraction item = _attractionService.GetAttractionById(id);
            if (item == null)
            {
                return NotFound();
            }
            AttractionDetailsVM attraction = new AttractionDetailsVM()
            {
                Id = item.Id,
                AttractionName = item.AttractionName,
                CategoryId = item.CategoryId,
                CategoryName = item.Category.CategoryName,
                Picture = item.Picture,
                Description = item.Description

              
            };
            return View(attraction);
        }
        // GET: AttractionController/Create
        public ActionResult Create()
        {
            var attraction = new AttractionCreateVM();
           
            attraction.Categories = _categoryService.GetCategories()
               .Select(x => new CategoryPairVM()
               {
                   Id = x.Id,
                   Name = x.CategoryName
               }).ToList();
            return View(attraction);

        }
        // POST: AttractionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] AttractionCreateVM attraction)
        {
            if (ModelState.IsValid)
            {
                var createdId = _attractionService.Create(attraction.AttractionName, 
                                                        attraction.Picture,
                                                       attraction.Description, attraction.CategoryId);
                if (createdId)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View();

        }

        // GET: AttractionController/Edit/5
        public ActionResult Edit(int id)
        {
            Attraction attraction = _attractionService.GetAttractionById(id);
            if (attraction == null)
            {
                return NotFound();
            }

            AttractionEditVM updatedAttraction = new AttractionEditVM()
            {
                Id = attraction.Id,
                AttractionName = attraction.AttractionName,
                
                CategoryId = attraction.CategoryId,
                // CategoryName = product.Category.CategoryName,
                Picture = attraction.Picture,
                Description = attraction.Description

              
            };
           

            updatedAttraction.Categories = _categoryService.GetCategories()
               .Select(c => new CategoryPairVM()
               {
                   Id = c.Id,
                   Name = c.CategoryName
               })
               .ToList();
            return View(updatedAttraction);
        }

        // POST: AttractionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AttractionEditVM attraction)
        {
            {
                if (ModelState.IsValid)
                {
                    var updated = _attractionService.Update(id, attraction.AttractionName,
                                                        attraction.Picture,
                                                       attraction.Description, attraction.CategoryId);
                    if (updated)
                    {
                        return this.RedirectToAction("Index");
                    }

                }
                return View(attraction);
            }
        }


        // GET: AttractionController/Delete/5
        public ActionResult Delete(int id)
        {
            Attraction item = _attractionService.GetAttractionById(id);
            if (item == null)
            {
                return NotFound();
            }
            AttractionDeleteVM attraction = new AttractionDeleteVM()
            {
                Id = item.Id,
                AttractionName = item.AttractionName,
                CategoryId = item.CategoryId,
                CategoryName = item.Category.CategoryName,
                Picture = item.Picture,
                Description = item.Description
                ,
             
            };
            return View(attraction);
        }

        // POST: AttractionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)


        {
            var deleted = _attractionService.RemoveById(id);

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
