using BulgariaApp.Data;
using BulgariaApp.Entities;
using BulgariaApp.Models.Reservation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BulgariaApp.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ReservationController : Controller
    {
        public readonly ApplicationDbContext context;

        public ReservationController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: ReservationController
        public ActionResult Index()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = context.Users.SingleOrDefault(u => u.Id == userId);
            List<ReservationIndexVM> reservations = context.Reservations
                .Select(x => new ReservationIndexVM
                {
                    Id = x.Id,
                    ReservationDate = x.ReservationDate.ToString("dd-MMM,yyyy hh:mm", CultureInfo.InvariantCulture),
                    UserId = x.UserId,
                    User = x.User.UserName,
                    ExcursionId = x.ExcursionId,
                    Excursion = x.Excursion.ExcurionName,
                    Picture = x.Excursion.Picture,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    Discount = x.Discount,
                    TotalPrice = x.TotalPrice,

                }).ToList();
            return View(reservations);
        }
        [AllowAnonymous]
        public IActionResult MyReservations(string searchString)
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = this.context.Users.SingleOrDefault(u => u.Id == currentUserId);
            if (user == null)
            {
                return null;
            }
            List<ReservationIndexVM> reservations = context.Reservations.Where(x => x.UserId == user.Id).Select(x => new ReservationIndexVM
            {
                Id = x.Id,
                ReservationDate = x.ReservationDate.ToString("dd-MMM,yyyy hh:mm", CultureInfo.InvariantCulture),
                UserId = x.UserId,
                User = x.User.UserName,
                ExcursionId = x.ExcursionId,
                Excursion = x.Excursion.ExcurionName,
                Picture = x.Excursion.Picture,
                Quantity = x.Quantity,
                Price = x.Price,
                Discount = x.Discount,
                TotalPrice = x.TotalPrice,
                
            }).ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                reservations = reservations.Where(r => r.Excursion.ToLower().Contains(searchString.ToLower())).ToList();
            }


            return this.View(reservations);
        }

        [AllowAnonymous]

        // GET: ReservationController/Create
        public ActionResult Create(int excursionId, int quantity)
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = this.context.Users.SingleOrDefault(u => u.Id == userId);
            var excursion = this.context.Excursions.SingleOrDefault(x => x.Id == excursionId);
            if (user == null || excursion == null || excursion.MaxVisitors < quantity)
            {
                return this.RedirectToAction("Index", "Excursion");
            }

            ReservationConfirmVM reservationFromDb = new ReservationConfirmVM
            {

                UserId = userId,
                User = user.UserName,
                ExcursionId = excursionId,
                ExcursionName = excursion.ExcurionName,
                Picture = excursion.Picture,
                Quantity = quantity,
                Price = excursion.Price,
                Discount = excursion.Discount,
                TotalPrice = quantity * excursion.Price - quantity * excursion.Price * excursion.Discount / 100
            };
            return View(reservationFromDb);
        }

        // POST: ReservationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Create(ReservationConfirmVM bindingModel)
        {
            if (this.ModelState.IsValid)
            {
                string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = this.context.Users.SingleOrDefault(u => u.Id == userId);
                var excursion = this.context.Excursions.SingleOrDefault(x => x.Id == bindingModel.ExcursionId);
                if (user == null || excursion == null || excursion.MaxVisitors < bindingModel.Quantity || bindingModel.Quantity == 0)
                {
                    return this.RedirectToAction("Index", "Excursion");
                }
                Reservation reservationFromDb = new Reservation
                {
                    ReservationDate = DateTime.UtcNow,
                    ExcursionId = bindingModel.ExcursionId,
                    UserId = userId,
                    Quantity = bindingModel.Quantity,
                    Price = excursion.Price,
                    Discount = excursion.Discount,

                };

                excursion.MaxVisitors -= bindingModel.Quantity;

                this.context.Excursions.Update(excursion);
               this.context.Reservations.Add(reservationFromDb);
                this.context.SaveChanges();
            }
            return this.RedirectToAction("Index", "Excursion");
        }


    }
}
