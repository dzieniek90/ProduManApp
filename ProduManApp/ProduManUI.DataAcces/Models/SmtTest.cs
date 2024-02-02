using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduManUI.DataAcces.Models
{
    public class SmtTest
    {
        public int Id { get; set; }

        public string CustomerOrderNumber { get; set; }

        public int Quantity { get; set; }

        public ProductionStatus Status { get; set; }
    }
    public enum ProductionStatus
    {
        Waiting,
        InProgress,
        Complete
    }
}
