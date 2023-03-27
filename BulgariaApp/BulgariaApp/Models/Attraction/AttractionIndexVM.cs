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
        [Display(Name = "Picture1")]
        public string Picture1 { get; set; }
        [Display(Name = "Picture2")]
        public string Picture2 { get; set; }
        [Display(Name = "Picture3")]
        public string Picture3 { get; set; }
        [Display(Name = "Picture4")]
        public string Picture4 { get; set; }
        public int CategoryId { get; set; }
        [Display(Name ="Category")]
        public string CategoryName { get; set; }

    }
}
