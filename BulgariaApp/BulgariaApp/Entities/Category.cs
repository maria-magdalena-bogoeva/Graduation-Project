using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BulgariaApp.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(45)]
        public string CategoryName { get; set; }

        public virtual IEnumerable<Attraction> Attractions { get; set; } = new List<Attraction>();
    }
}
