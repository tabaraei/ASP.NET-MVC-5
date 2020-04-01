using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string title { get; set; }
        public int parentId { get; set; }
        public string path { get; set; }
    }
}