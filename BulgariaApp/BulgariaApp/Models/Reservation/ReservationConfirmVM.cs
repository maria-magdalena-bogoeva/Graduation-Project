using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BulgariaApp.Models.Reservation
{
    public class ReservationConfirmVM
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
       

        public string UserId { get; set; }
        public string User { get; set; }
        [Required]
        public int ExcursionId { get; set; }
        public string ExcursionName { get; set; }


        public string Picture { get; set; }
        [Required]
        [Range(0,100)]
        [Display(Name = "Qunatity")]
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
