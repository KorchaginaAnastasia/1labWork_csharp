using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClientsDB
{
    public class AddSale
    {
        public static void addSale(SalesDBStorage storage)
        {
            Console.WriteLine("Добавление продажи топлива:");
            Console.WriteLine("Выберите номер аптозаправки:");
            List<GasStation> gasStations = storage.GetGasStations();
            for (int i = 0; i < gasStations.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {gasStations[i].GSID}");
            }

            int gsIndex;
            if (int.TryParse(Console.ReadLine(), out gsIndex) && gsIndex >= 1 && gsIndex <= gasStations.Count)
            {
                GasStation selectedgs = gasStations[gsIndex - 1];

                string saleDate = PromptValidInput("Введите дату продажи топлива в формате ДД.ММ.ГГ:", IsValidDate);

                Console.WriteLine("Введите карт-счет клиента:");
                string saleClientCard = Console.ReadLine();

                Sale newSale = new Sale() { SaleDate = saleDate, GasStation = selectedgs, ClientCard = saleClientCard };
                storage.addSale(newSale);


                Console.WriteLine("Продажа топлива успешно добавлена.");
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
            }
        }
        private static string PromptValidInput(string promptMessage, Func<string, bool> isValidInput)
        {
            string input;
            do
            {
                Console.WriteLine(promptMessage);
                input = Console.ReadLine().Trim();
            } while (!isValidInput(input));

            return input;
        }
        private static bool IsValidDate(string date)
        {
            DateTime parsedDate;
            return DateTime.TryParseExact(date, "dd.MM.yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate); 
        }
    }
}