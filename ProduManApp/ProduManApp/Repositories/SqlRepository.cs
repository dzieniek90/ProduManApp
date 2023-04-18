using Microsoft.EntityFrameworkCore;
using ProduManApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduManApp.Repositories
{
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly DbSet<T> dbSet;
        private readonly DbContext dbContext;

        public EventHandler<T> ItemAdded;
        public EventHandler<T> ItemRemoved;

        public SqlRepository(DbContext dbContext )
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Add(T item)
        {
            dbSet.Add(item);
            ItemAdded?.Invoke(this, item);
        }

        public void Remove(T item)
        {
            dbSet.Remove(item);
            ItemRemoved?.Invoke(this, item);

        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
