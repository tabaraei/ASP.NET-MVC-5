using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public partial class User
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string username { get; set; }

        [MaxLength(100)]
        public string password { get; set; }

        [MaxLength(50)]
        public string email { get; set; }


        //public virtual Role RoleTable { get; set; }
        //[ForeignKey("RoleTable")]
        public int roleId { get; set; }
    }
}