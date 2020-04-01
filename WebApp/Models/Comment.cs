using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public partial class Comment
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string username { get; set; }


        [MaxLength(100)]
        public string imageUrl { get; set; }

        public string description { get; set; }

        public bool status { get; set; }


        //public virtual Blog BlogTable { get; set; }
        //[ForeignKey("BlogTable")]
        public int blogID { get; set; }
    }
}