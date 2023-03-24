using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BulgariaApp.Models.Excursion
{
    public class ExcursionDeleteVM
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "ExcursionName")]
        public string ExcurionName { get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Picture")]
        public string Picture { get; set; }

        [Display(Name = "Picture1")]
        public string Picture1 { get; set; }
        [Display(Name = "Picture2")]
        public string Picture2 { get; set; }
        [Display(Name = "Picture3")]
        public string Picture3 { get; set; }
        [Display(Name = "Picture4")]
        public string Picture4 { get; set; }
        public int AttractionId { get; set; }


        [Display(Name = "Attraction")]
        public string AttractionName { get; set; }


        [Display(Name = "Max Visitors")]
        public int MaxVisitors { get; set; }


        [Display(Name = "Price")]
        public decimal Price { get; set; }


        [Display(Name = "Discount")]

        public decimal Discount { get; set; }
    }
}
