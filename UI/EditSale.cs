using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClientsDB.AddSale;


namespace ClientsDB
{
    internal class EditSale
    {
        public static void editSale(SalesDBStorage storage)
        {
            Console.WriteLine("Редактирование продажи топлива:");
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

                Console.WriteLine("Выберите номер продажи для редактировaния:");
                List<Sale> sales = selectedgs.Sales;
                for (int i = 0; i < sales.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {sales[i].SaleDate} {sales[i].ClientCard}");
                }

                int saleIndex;
                if (int.TryParse(Console.ReadLine(), out saleIndex) && saleIndex >= 1 && saleIndex <= sales.Count)
                {
                    Console.WriteLine("Что редактировать?");
                    Console.WriteLine(" 1. дату");
                    Console.WriteLine(" 2. карт-счет клиента");
                    int choice = Console.Read();
                    if (choice == '1')
                    {
                        string newSaleDate = PromptValidInput("Введите новую дату продажи топлива в формате ДД.ММ.ГГ:", IsValidDate);

                        Sale notEditedSale = sales[saleIndex - 1];
                        notEditedSale.SaleDate = newSaleDate;
                        storage.EditSale(notEditedSale);
                    }
                    if (choice == '2')
                    {
                        Console.WriteLine("Введите карт-счет клиента:");
                        string? saleClientCard = Console.ReadLine();

                        Sale notEditedSale = sales[saleIndex - 1];
                        notEditedSale.ClientCard = saleClientCard;
                        storage.EditSale(notEditedSale);
                    }

                    Console.WriteLine("Продажа успешно была редактирована.");
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
