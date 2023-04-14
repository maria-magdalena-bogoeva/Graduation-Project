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
        [Required]
        [MinLength(5, ErrorMessage = "ExcursionName must be between 5 - 20 symbols")]
        [MaxLength(20)]
        public string ExcurionName { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "Description must be between 50 - 5000 symbols")]
        [MaxLength(5000)]

        public string Description { get; set; }
        [Required]
        public string Picture { get; set; }
        
        public string Picture1 { get; set; }
       
        public string Picture2 { get; set; }
    
        public string Picture3 { get; set; }

        public string Picture4 { get; set; }


        public int AttractionId { get; set; }
        public virtual List<AttractionPairVM> Attractions { get; set; }


        [Required]
        [Range(1, 30, ErrorMessage = "Visitors must be between 1 - 30 symbols ")]

        public int MaxVisitors { get; set; }

        [Required]
        [Range(100, 1000)]
        public decimal Price { get; set; }

        public decimal Discount { get; set; }
    }
}

