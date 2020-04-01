using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Setting
    {
        public int Id { get; set; }

        public string title { get; set; }

        public string themeColor { get; set; }

        public int blogCount { get; set; }

        public string email { get; set; }
    }
}