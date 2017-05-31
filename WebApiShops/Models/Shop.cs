using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiShops.Models
{
    public class Shop
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Error: Name is NULL")]
        public string Name { get; set; }
        public string Owner { get; set; }
    }
}