using ProduManApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduManApp.Extensions
{
    public static class OrderStatusesExtensions
    {
        public static string ToPolishString(this OrderStatuses status)
        {
            switch (status)
            {
                case OrderStatuses.NewOrder:
                    return "Nowe zlecenie";
                case OrderStatuses.InProgres:
                    return "W trakcie";
                case OrderStatuses.Completed:
                    return "Zakończone";
                default:
                    return string.Empty;
            }
        }
    }
}
