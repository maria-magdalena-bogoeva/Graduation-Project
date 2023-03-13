using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BulgariaApp.Models.Excursion
{
    public class ExcursionIndexVM
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Excursion")]
        public string ExcurionName { get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Info")]
        public string Description { get; set; }
        [Display(Name = "Picture")]
        public string Picture { get; set; }


        public int AttractionId { get; set; }


        [Display(Name="Attraction")]
        public string AttractionName { get; set; }


        [Display(Name = "Visitors")]
        public int MaxVisitors { get; set; }


        [Display(Name = "Price")]
        public decimal Price { get; set; }


        [Display(Name = "Discount")]

        public decimal Discount { get; set; }
    }
}
