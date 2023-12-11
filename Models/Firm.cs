using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1
{
    public class Firm
    {//нет key 
        public int FirmID { get; set; }
        public string? FirmName { get; set; }
        public string? FirmLegalAdress { get; set; }
        public string? FirmPhone { get; set; }

        public List<GasStation> GasStations { get; set; } = new();

    }
}