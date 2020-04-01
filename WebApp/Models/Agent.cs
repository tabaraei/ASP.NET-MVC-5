using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public partial class Agent
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string name { get; set; }

        [MaxLength(30)]
        public string city { get; set; }
    }
}