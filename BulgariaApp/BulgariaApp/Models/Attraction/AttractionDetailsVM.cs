using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BulgariaApp.Models.Attraction
{
    public class AttractionDetailsVM
    {
        [Key]
        public int Id { get; set; }
        public string AttractionName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
