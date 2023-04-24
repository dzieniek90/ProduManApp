using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduManApp.Entities
{
    public class ComplaintOrder:Order
    {
        public override string ToString() => base.ToString() + "    (Zlecenie reklamacyjne)";
    }
}
