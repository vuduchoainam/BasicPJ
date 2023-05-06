using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BasicPJ.Models
{
    public class PropertyProduct
    {
        [Key]
        public string PropertyProductId { get; set; }
        public Product Product { get; set; }
        public string PropertyProductName { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}