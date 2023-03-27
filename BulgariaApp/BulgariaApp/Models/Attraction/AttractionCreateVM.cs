using BulgariaApp.Models.Category;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BulgariaApp.Models.Attraction
{
    public class AttractionCreateVM
    {
        public AttractionCreateVM()
        {
            Categories = new List<CategoryPairVM>();
        }
        [Key]
        public int Id { get; set; }
        public string AttractionName { get; set; }
        
       
        public string Description { get; set; }
      
        public string Picture { get; set; }
        public string Picture1 { get; set; }

        public string Picture2 { get; set; }

        public string Picture3 { get; set; }

        public string Picture4 { get; set; }


        public int CategoryId { get; set; }
        public virtual List<CategoryPairVM> Categories { get; set; }

       // public virtual IEnumerable<Excursion> Excursions { get; set; } = new List<Excursion>();

      
    }
}
