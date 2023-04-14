using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BulgariaApp.Models.Excursion
{
    public class ExcursionDetailsVM
    {
        [Key]
        public int Id { get; set; }
        public string ExcurionName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string Picture1 { get; set; }
        public string Picture2 { get; set; }
        public string Picture3 { get; set; }
        public string Picture4 { get; set; }
        public int AttractionId { get; set; }
        public string AttractionName { get; set; }
        public int MaxVisitors { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
    }
}
