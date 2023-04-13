﻿using System;
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


        public override string ToString() => $"Id: {Id}, Produkt: {ProductName}";
    }
}
