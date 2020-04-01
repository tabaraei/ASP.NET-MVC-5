using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services
{
    public class DatabaseRepository<TEntity> where TEntity:class
    {
        private DB entity;
        private DbSet<TEntity> _dbset;

        // Constructor
        public DatabaseRepository(DB context)
        {
            _dbset = context.Set<TEntity>();
            entity = context;
        }

        public void Create(TEntity record)
        {
            _dbset.Add(record);
        }

        public List<TEntity> Read()
        {
            return _dbset.ToList();
        }

        public TEntity Read(int id)
        {
            return _dbset.Find(id);
        }

        public virtual List<TEntity> Read(Expression<Func<TEntity, bool>> where = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null, string includes = "")
        {
            IQueryable<TEntity> query = _dbset;

            if (where != null)
            {
                query = query.Where(where);
            }

            if (orderby != null)
            {
                query = orderby(query);
            }

            if (includes != "")
            {
                foreach (string include in includes.Split(','))
                {
                    query = query.Include(include);
                }
            }

            return query.ToList();
        }

        public void Update(TEntity newRecord)
        {
            _dbset.Attach(newRecord);
            entity.Entry(newRecord).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete()
        {
            _dbset.RemoveRange(Read());
        }

        public void Delete(int id)
        {
            _dbset.Remove(Read(id));
        }

        public bool Save()
        {
            try { entity.SaveChanges(); return true; }
            catch { return false; }
        }
    }
}
