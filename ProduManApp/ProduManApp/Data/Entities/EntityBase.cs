using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduManApp.Entities
{
    public abstract class EntityBase : IEntity
    {
        public int Id { get; set; }

    }
}
