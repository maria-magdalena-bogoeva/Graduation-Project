using BulgariaApp.Models.Category;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BulgariaApp.Models.Attraction
{
    public class AttractionEditVM
    {
        public AttractionEditVM()
        {
            Categories = new List<CategoryPairVM>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "AttractionName must be between 5 - 20 symbols")]
        [MaxLength(20)]
        public string AttractionName { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Description must be between 50 - 5000 symbols")]
        [MaxLength(5000)]

        public string Description { get; set; }

        public string Picture { get; set; }
        public string Picture1 { get; set; }
        public string Picture2 { get; set; }
        public string Picture3 { get; set; }
        public string Picture4 { get; set; }


        public int CategoryId { get; set; }
        public virtual List<CategoryPairVM> Categories { get; set; }
    }
}
