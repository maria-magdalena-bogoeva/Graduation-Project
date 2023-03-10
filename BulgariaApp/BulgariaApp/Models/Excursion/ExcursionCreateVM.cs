using BulgariaApp.Entities;
using BulgariaApp.Models.Attraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BulgariaApp.Models.Excursion
{
    public class ExcursionCreateVM
    {

        public ExcursionCreateVM()
        {
            Attractions = new List<AttractionPairVM>();
        }
        [Key]
        public int Id { get; set; }

        public string ExcurionName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }



        public int AttractionId { get; set; }
        public virtual List<AttractionPairVM> Attractions { get; set; }



        public int MaxVisitors { get; set; }


        public decimal Price { get; set; }

        public decimal Discount { get; set; }
    }
}

