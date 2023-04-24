using ProduManApp.Components.CsvReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduManApp.Components.DataProviders.Models
{
    public class CarsByManufacturer
    {
        public Manufacturer Manufacturer { get; set; }
        public IEnumerable<Car> Cars { get; set; }
    }

}
