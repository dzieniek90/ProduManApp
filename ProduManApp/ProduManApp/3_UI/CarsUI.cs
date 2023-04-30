using ProduManApp.Components.DataProviders;
using ProduManApp.Components.MyXmlWriter;

namespace ProduManApp.UI
{
    public class CarsUI : ICarsUI
    {
        private ICarsProvider _carsProvider;

        public CarsUI(ICarsProvider carsProvider)
        {
            _carsProvider = carsProvider;
        }

        public void RunActions()
        {
            DisplayCarStatisticsByManufacturer();
            DisplayJoinedCarsAndManufacturers();
            DisplayGroupJoinCarsAndManufacturers();
            SaveCarsByAllManufacturersToXml();
        }

        private void DisplayCarStatisticsByManufacturer()
        {
            var groups = _carsProvider.GetCarStatisticsByManufacturer();

            foreach (var group in groups)
            {
                Console.WriteLine($"{group.Name}");
                Console.WriteLine($"\t Max: {group.Max}");
                Console.WriteLine($"\t Average: {group.Name}");
            }
        }

        private void DisplayJoinedCarsAndManufacturers()
        {
            var carsInCountry = _carsProvider.GetJoinedCarsAndManufacturers();

            foreach (var car in carsInCountry)
            {
                Console.WriteLine($"Country: {car.Country}");
                Console.WriteLine($"\t Name: {car.Name}");
                Console.WriteLine($"\t Combined: {car.Combined}");
            }
        }

        private void DisplayGroupJoinCarsAndManufacturers()
        {
            var groups = _carsProvider.GetCarsByAllManufacturers();

            foreach (var group in groups)
            {
                Console.WriteLine($"Manufacturer: {group.Manufacturer.Name}");
                Console.WriteLine($"\t Cars: {group.Cars.Count()}");
                Console.WriteLine($"\t Max: {group.Cars.Max(x => x.Combined)}");
                Console.WriteLine($"\t Min: {group.Cars.Min(x => x.Combined)}");
                Console.WriteLine($"\t Avg: {group.Cars.Average(x => x.Combined)}");
                Console.WriteLine();
            }
        }

        private void SaveCarsByAllManufacturersToXml()
        {
            var filePath = "xmlManufacturers.xml";

            var cars = _carsProvider.GetCarsByAllManufacturers();

            MyXmlWriter.CarsByAllManufacturersToXml(cars, filePath);
        }
    }
}