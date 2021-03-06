﻿using System;
using System.ComponentModel.DataAnnotations;

namespace RANKSOnlineWholesale.Models
{
    public class DeliveryDetails
    {
        public int DeliveryId { get; set; }
        [Required]
        public Nullable<int> CustomerId { get; set; }     
        public Nullable<int> OrderId { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        [Required]
        public string AddressLine { get; set; }
        [Required]
        public string Parish { get; set; }
        public Nullable<decimal> AmountPaid { get; set; }
        [Required]
        public string PaymentType { get; set; }

      
    }
}