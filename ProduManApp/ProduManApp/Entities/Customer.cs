using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduManApp.Entities
{
    public class Customer : EntityBase
    {
        public string Name { get; set; }
        public string Country { get; set; }
        //public List<Order> Orders { get; set; }
        public override string ToString() => $"{Id,-5} {Name,-20} {Country,-20}";

    }
}
