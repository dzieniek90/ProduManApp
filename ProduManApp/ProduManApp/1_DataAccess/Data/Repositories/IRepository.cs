using ProduManApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduManApp.Data.Repositories
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class, IEntity
    {
        EventHandler<T> ItemAdded { get; set; }
        EventHandler<T> ItemRemoved { get; set; }
        EventHandler<T> ItemEdited { get; set; }
    }
}
