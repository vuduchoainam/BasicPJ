﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BasicPJ.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string BookingDate { get; set; }
        public string NumberOfGuest { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}