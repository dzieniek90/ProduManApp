using ProduManApp.Components.CsvReader.Models;
using ProduManApp.Components.CsvReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProduManApp.Components.DataProviders.Models;

namespace ProduManApp.Components.DataProviders
{
    public class CarsProvider : ICarsProvider
    {
        ICsvReader _csvReader;
        List<Car> cars;
        List<Manufacturer> manufacturers;

        public CarsProvider(ICsvReader csvReader)
        {
            _csvReader = csvReader;
            cars = _csvReader.ProcessCars("Resources\\Files\\fuel.csv");
            manufacturers = _csvReader.ProcessManufacturers("Resources\\Files\\manufacturers.csv");

        }

        public IEnumerable<dynamic> GetCarStatisticsByManufacturer()
        {
            var groups = cars.GroupBy(c => c.Manufacturer)
                .Select(g => new
                {
                    Name = g.Key,
                    Max = g.Max(c => c.Combined),
                    Average = g.Average(c => c.Combined),
                })
                .OrderBy(x => x.Average);

            return groups;
        }

        public IEnumerable<dynamic> GetJoinedCarsAndManufacturers()
        {
            var carsInCountry = cars.Join(
                manufacturers,
                x => x.Manufacturer,
                x => x.Name,
                (car, manufacturer) =>
                    new
                    {
                        manufacturer.Country,
                        car.Name,
                        car.Combined
                    })
                .OrderByDescending(x => x.Combined)
                .ThenBy(x => x.Name);

            return carsInCountry;
        }

        public IEnumerable<CarsByManufacturer> GetCarsByAllManufacturers()
        {
            var groups = manufacturers.GroupJoin(
                cars,
                manufacturer => manufacturer.Name,
                car => car.Manufacturer,
                (m, g) =>
                    new CarsByManufacturer
                    {
                        Manufacturer = m,
                        Cars = g
                    })
                .OrderBy(x => x.Manufacturer.Name);

            return groups;
        }
    }
}
