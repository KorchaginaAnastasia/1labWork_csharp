using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientsDB
{
    public class RemoveSale
    {
        public static void removeSale(SalesDBStorage storage)
        {
            Console.WriteLine("Удаление продажи топлива:");
            Console.WriteLine("Выберите номер автозаправки:");

            List<GasStation> gasStations = storage.GetGasStations();
            for (int i = 0; i < gasStations.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {gasStations[i].GSID}");
            }

            int groupIndex;
            if (int.TryParse(Console.ReadLine(), out groupIndex) && groupIndex >= 1 && groupIndex <= gasStations.Count)
            {
                GasStation selectedgs = gasStations[groupIndex - 1];

                Console.WriteLine("Выберите номер продажи для удаления:");
                List<Sale> sales = selectedgs.Sales;
                for (int i = 0; i < sales.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {sales[i].SaleDate} {sales[i].SaleID}");
                }

                int saleIndex;
                if (int.TryParse(Console.ReadLine(), out saleIndex) && saleIndex >= 1 && saleIndex <= sales.Count)
                {
                    Sale selectedStudent = sales[saleIndex - 1];
                    storage.removeSale(selectedStudent.SaleID);

                    Console.WriteLine("Продажа успешно удалена.");
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
            }
        }
    }
}