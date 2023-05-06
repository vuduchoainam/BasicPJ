using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BasicPJ.Models
{
    public class OptionProduct
    {
        [Key]
        public string OptionProductId { get; set; }
        public Product Product { get; set; }
        public string OptionProductName { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}