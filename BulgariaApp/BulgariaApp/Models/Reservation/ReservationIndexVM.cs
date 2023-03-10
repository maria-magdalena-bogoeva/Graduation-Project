using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulgariaApp.Models.Reservation
{
    public class ReservationIndexVM
    {
        public int Id { get; set; }
      
        public string ReservationDate { get; set; }

        public string UserId { get; set; }
        public string User { get; set; }
        
        public int ExcursionId { get; set; }
        public string Excursion { get; set; }
        public string Picture { get; set; }
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
