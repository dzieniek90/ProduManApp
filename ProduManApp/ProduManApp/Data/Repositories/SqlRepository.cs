using Microsoft.EntityFrameworkCore;
using ProduManApp.Data;
using ProduManApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduManApp.Data.Repositories
{
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly DbSet<T> dbSet;
        private readonly ProduManAppDbContext dbContext;

        public SqlRepository(ProduManAppDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        public EventHandler<T> ItemAdded { get; set; }
        public EventHandler<T> ItemRemoved { get; set; }
        public EventHandler<T> ItemEdited { get; set; }


        public void Update(T item)
        {
            dbSet.Update(item);
            ItemEdited?.Invoke(this, item);
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
