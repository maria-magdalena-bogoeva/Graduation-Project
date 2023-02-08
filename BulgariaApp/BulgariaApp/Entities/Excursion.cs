using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BulgariaApp.Entities
{
    public class Excursion
    {
        public int Id { get; set; }
        [Required]
        public string ExcurionName { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Picture { get; set; }

       
        [Required]
        public int AttractionId { get; set; }
        public virtual Attraction Attraction { get; set; }

        [Required]
        [Range(1,30)]

        public int MaxVisitors { get; set; }


        [Required]

        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public virtual IEnumerable<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
