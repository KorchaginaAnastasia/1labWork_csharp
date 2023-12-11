using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1
{
    public class FuelType
    {
        [Key]
        public int FuelID { get; set; }
        public string? FuelKind { get; set; }
        public string? FuelMeasure { get; set; }

        public List<Sale> Sales { get; set; } = new();

    }
}