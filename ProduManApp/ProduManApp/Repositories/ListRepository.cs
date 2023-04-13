using ProduManApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduManApp.Repositories
{
    public class ListRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly List<T> items = new();

        public void Add(T item)
        {
            item.Id = items.Count +1;
            items.Add(item);
        }

        public IEnumerable<T> GetAll()
        {
            return items.ToList();
        }

        public T GetById(int id)
        {
            return items.Single(i => i.Id == id);
        }

        public void Remove(T item)
        {
            items.Remove(item);
        }

        public void Save()
        {
            // w liście nie obsługujemy save
        }
    }
}
