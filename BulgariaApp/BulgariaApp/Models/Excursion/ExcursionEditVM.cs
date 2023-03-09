using BulgariaApp.Models.Attraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BulgariaApp.Models.Excursion
{
    public class ExcursionEditVM
    {
        public ExcursionEditVM()
        {
            Attractions = new List<AttractionPairVM>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "ExcursionName")]
        public string ExcurionName { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]

        public DateTime EndDate { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Picture")]
        public string Picture { get; set; }

        [Required]
        [Display(Name = "Attraction")]
        public int AttractionId { get; set; }
        public virtual List<AttractionPairVM> Attractions { get; set; }

        [Required]
        [Range(0,300)]
        [Display(Name = "Max Visitors")]
        public int MaxVisitors { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }


        [Display(Name = "Discount")]

        public decimal Discount { get; set; }
    }
}
