using ProduManApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduManApp.Helpers
{
    public class OrderLogger
    {
        public void AddingOrder(object? sender, Order e)
        {
            AddLog(CreateLog(e, "Dodanie zlecenia"));
        }

        public void DeletingOrder(object? sender, Order e)
        {
            AddLog(CreateLog(e, "Usunięcie zlecenia"));
        }

        public void EditingOrder(object? sender, Order e)
        {
            AddLog(CreateLog(e, "Edycja zlecenia"));
        }

        string CreateLog(Order order, string action)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            return ($"[{timestamp}] - {action} - {order}");
        }

        void AddLog(string log)
        {
            string solutionDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", ".."));
            string fileName = "RepositoryLogs.txt";
            string filePath = Path.Combine(solutionDirectory, fileName);

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(log);
            }
        }
    }
}
