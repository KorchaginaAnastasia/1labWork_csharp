using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1
{
    public class Sale
    {
        [Key]
        public int SaleID { get; set; }
        public string? SaleDate { get; set; }
        public string? ClientCard { get; set; }
        public int? GasStationID { get; set; }
        public int? FuelID { get; set; }
        public int? NumOfSales { get; set; } //проверить на неотрицательность 

        public FuelType? FuelType { get; set; }
        public GasStation? GasStation { get; set; }
        public Sale? Client { get; set; }
    }
}