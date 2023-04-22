using ProduManApp.Components.CsvReader.Models;
using ProduManApp.Components.DataProviders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProduManApp.Components.MyXmlWriter
{
    public class MyXmlWriter
    {
        public static void CarsByAllManufacturersToXml(IEnumerable<CarsByManufacturer> groups, string filePath)
        {
            var document = new XDocument();

            var xmlManufacturers = new XElement("Manufacturers", groups
                .Select(x =>
                    new XElement("Manufacturer",
                        new XAttribute("Name", x.Manufacturer.Name),
                        new XAttribute("Country", x.Manufacturer.Country),
                        new XElement("Cars",
                            new XAttribute("Country", x.Manufacturer.Country),
                            new XAttribute("CombinedSum", x.Cars.Sum(c => c.Combined)),
                            x.Cars.Select(c =>
                                new XElement("Car",
                                    new XAttribute("Model", c.Name),
                                    new XAttribute("Combined", c.Combined)))))));

            document.Add(xmlManufacturers);
            document.Save(filePath);
        }
    }
}