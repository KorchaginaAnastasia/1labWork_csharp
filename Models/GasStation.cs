using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class GasStation
    {
        [Key]
        public int GSID { get; set; }
        public string? GSFirm { get; set; }
        public string? GSAdress { get; set; }
        public int? NumOfGasers { get; set; }
        public string? GSFuelTypes { get; set; }

        public Firm? Firm { get; set; }
        public List<FuelType> FuelTypes { get; set; } = new();
        public List<Sale> Sales { get; set; } = new();
    }
}