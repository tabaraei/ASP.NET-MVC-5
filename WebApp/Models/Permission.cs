using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Permission
    {
        //public virtual Role RoleTable { get; set; }
        //public virtual Module ModuleTable { get; set; }

        [Key]
        [Column(Order = 1)]
        //[ForeignKey("RoleTable")]
        public int roleId { get; set; }


        [Key]
        [Column(Order = 2)]
        //[ForeignKey("ModuleTable")]
        public int moduleId { get; set; }

        public bool create { get; set; }
        public bool read { get; set; }
        public bool update { get; set; }
        public bool delete { get; set; }
    }
}