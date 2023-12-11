using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    public class SalesDBStorage
    {
        private readonly SalesContext _context;
        public SalesDBStorage(SalesContext context)
        {
            _context = context;
        }
        public void addSale(Sale sale)
        {
            _context.Sales.Add(sale);
            _context.SaveChanges();
        }
        public List<Sale> GetAllSales()
        {
            return _context.Sales.ToList<Sale>();
        }
        public List<GasStation> GetGasStations()
        {
            return _context.GasStations.ToList<GasStation>();
        }
        public void removeSale(int saleID)
        {
            _context.Remove(_context.Sales
            .FirstOrDefault(p => p.SaleID.Equals(saleID)));
            _context.SaveChanges();
        }

        public void EditSale(Sale sale)
        {
            _context.Entry(sale).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}