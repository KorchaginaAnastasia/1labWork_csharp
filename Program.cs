using System;
using System.Collections.Generic;
using ConsoleApp1;
using static ClientsDB.AddSale;
using static ClientsDB.RemoveSale;
using static ClientsDB.EditSale;
class Program
{
    static void Main(string[] args)
    {
        SalesDBStorage saleDBStorage = new SalesDBStorage(new SalesContext());

        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("Списки продаж по станциям автозаправок:");
            List<GasStation> gasStations = saleDBStorage.GetGasStations();
            foreach (GasStation gs in gasStations)
            {
                Console.WriteLine($" Код авт-ки: {gs.GSID} ({gs.Sales.Count} продаж) фирмa - {gs.GSFirm}, содержит {gs.NumOfGasers} колонок, типы топлива - {gs.GSFuelTypes}, {gs.GSAdress} ");

                List<Sale> sortedSales = gs.Sales;
                sortedSales.Sort((s1, s2) => s1.SaleDate.CompareTo(s2.SaleDate));

                foreach (Sale Sale in sortedSales)
                {
                    Console.WriteLine($"- {Sale.SaleDate} {Sale.ClientCard} ");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1 - Добавить продажу");
            Console.WriteLine("2 - Удалить продажу");
            Console.WriteLine("3 - Редактировать продажу");
            Console.WriteLine("0 - Выйти из приложения");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Console.Clear();
                    addSale(saleDBStorage);
                    break;
                case "2":
                    Console.Clear();
                    removeSale(saleDBStorage);
                    break;
                case "3":
                    Console.Clear();
                    editSale(saleDBStorage);
                    break;
                case "0":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                    break;
            }

            Console.WriteLine();
        }
    }
}