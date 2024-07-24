using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimplePOS.Models
{
    public class Inward
    {
        public int InwardId { get; set; }

        [Required]
        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }
        public Supplier? Supplier { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        public List<InwardProduct> InwardProducts { get; set; } = new List<InwardProduct>();
    }
}
