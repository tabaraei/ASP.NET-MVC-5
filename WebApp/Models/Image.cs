using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public partial class Image
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string title { get; set; }

        [MaxLength(100)]
        public string imageUrl { get; set; }

        public bool status { get; set; }
    }
}