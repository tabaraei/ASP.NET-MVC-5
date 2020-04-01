using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public partial class Property
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string title { get; set; }

        [MaxLength(20)]
        public string location { get; set; }
        public int bedCount { get; set; }
        public int showerCount { get; set; }

        [MaxLength(20)]
        public string area { get; set; }

        [MaxLength(20)]
        public string oldPrice { get; set; }

        [MaxLength(20)]
        public string newPrice { get; set; }

        [MaxLength(100)]
        public string imageUrl { get; set; }
    }
}