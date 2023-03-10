using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BulgariaApp.Entities
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }
      
        [Required]
        public int ExcursionId { get; set; }
        public virtual Excursion Excursion { get; set; }


        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        [Required]
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }
        public decimal TotalPrice
        {
            get 
            {
                return Quantity * Price - Quantity * Price * Discount / 100; 
            }
        }

    }
}
