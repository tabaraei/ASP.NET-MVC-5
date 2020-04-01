using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using WebApp.Models;

namespace WebApp.Models
{
    public partial class Blog
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string title { get; set; }

        [MaxLength(10)]
        public string blogDate { get; set; }

        [MaxLength(30)]
        public string author { get; set; }

        public string description { get; set; }

        [MaxLength(100)]
        public string imageUrl { get; set; }

        public bool status { get; set; }

        //[ForeignKey("CategoryTable")]
        public int categoryId { get; set; }

        //public virtual nothing CategoryTable { get; set; }
    }

    //public partial class Blog
    //{
    //    EF entity = new EF();
        
    //    public bool Create(Blog record)
    //    {
    //        entity.Blogs.Add(record);
    //        try { entity.SaveChanges(); return true; }
    //        catch { return false; }
    //    }

    //    public List<Blog> Read()
    //    {
    //        return entity.Blogs.ToList();
    //    }

    //    public Blog Read(int id)
    //    {
    //        return entity.Blogs.Find(id);
    //    }

    //    public bool Update(Blog record)
    //    {
    //        entity.Blogs.Attach(record);
    //        entity.Entry(record).State = System.Data.Entity.EntityState.Modified;
    //        try { entity.SaveChanges(); return true; }
    //        catch { return false; }
    //    }

    //    public bool Delete()
    //    {
    //        entity.Blogs.RemoveRange(Read());
    //        try { entity.SaveChanges(); return true; }
    //        catch { return false; }
    //    }

    //    public bool Delete(int id)
    //    {
    //        entity.Blogs.Remove(Read(id));
    //        try { entity.SaveChanges(); return true; }
    //        catch { return false; }
    //    }
    //}
}
