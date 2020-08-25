using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RANKSOnlineWholesale.Models
{
    public class CategoryDetail
    {
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }

    }

    public class ProductDetail
    {
        public int ProductId { get; set; }
        [Required]
        public Nullable<int> CategoryId { get; set; }
        [Required(ErrorMessage ="Product Name Required")]
        public string ProductName { get; set; }
        [Required(ErrorMessage ="Description Required")]
        public string ProductDescription { get; set; }
        [Required]
        public Nullable<int> Quantity { get; set; }
        [Required]
        public Nullable<decimal> Price { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public string ProductImage { get; set; }
        public SelectList Categories { get; set; }

    }
}