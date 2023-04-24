using ProduManApp.Components.DataProviders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduManApp.Components.DataProviders
{
    public interface ICarsProvider
    {
        IEnumerable<CarsByManufacturer> GetCarsByAllManufacturers();
        IEnumerable<dynamic> GetCarStatisticsByManufacturer();
        IEnumerable<dynamic> GetJoinedCarsAndManufacturers();
    }
}
