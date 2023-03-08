using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BulgariaApp.Entities
{
    public class Attraction
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string AttractionName { get; set; }
        [Required]
        [MinLength(20)]
        [MaxLength(150)]
        public string Description { get; set; }
        [Required]
        public string Picture { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual IEnumerable<Excursion> Excursions { get; set; } = new List<Excursion>();



    }
}
