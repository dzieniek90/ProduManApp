using ProduManApp.Extensions;
using ProduManApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduManApp.Entities
{
    public class Order : EntityBase
    {
        public string? OrderNumber { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public OrderStatuses Status { get; set; }
        public string Customer { get; set; }
        //public int CustomerId { get; set; }
        //public Customer Customer { get; set; }


        public override string ToString() => $"{Id,-5} {OrderNumber,-15} {ProductName,-20} {Quantity,-10} {Customer,-20} {Status.ToPolishString(),-15}";
    }
}
