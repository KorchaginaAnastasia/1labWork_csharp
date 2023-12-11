using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    public class SalesContext : DbContext
    {
        public DbSet<Sale> Clients { get; set; } = null;
        public DbSet<Firm> Firms { get; set; } = null;
        public DbSet<FuelType> FuelTypes { get; set; } = null;
        public DbSet<GasStation> GasStations { get; set; } = null;
        public DbSet<Sale> Sales { get; set; } = null;

        public SalesContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>().Property(x => x.SaleID).HasMaxLength(50);
            modelBuilder.Entity<GasStation>().HasData(
            new { GSID = 3801, GSFirm = "Лукойл", NumOfGasers = 6, GSFuelTypes = "92, 95", GSAdress = "ул. Ленинградская, 29В" },
            new { GSID = 7625, GSFirm = "Роснефть", NumOfGasers = 8, GSFuelTypes = "92, 95, ДТ", GSAdress = "ул. Космонавтов, 6А" },
            new { GSID = 5974, GSFirm = "Газпромнефть", NumOfGasers = 4, GSFuelTypes = "92, 95, газ", GSAdress = "ул. Остужева, 51" }
            );

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
                                         Database = ClientDb;
                                         Trusted_Connection = true");
        }
    }
}