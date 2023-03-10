using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BulgariaApp.Models.Attraction
{
    public class AttractionIndexVM
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Attraction")]
        public string AttractionName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public int CategoryId { get; set; }
        [Display(Name ="Category")]
        public string CategoryName { get; set; }

    }
}
