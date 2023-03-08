using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BulgariaApp.Models.Attraction
{
    public class AttractionPairVM
    {
        public int Id { get; set; }
        [Display(Name = "Attraction")]
        public string Name { get; set; }
    }
}
