using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CargoApp.Models
{
    public class CargoContext : DbContext
    {
        public CargoContext() : base("cargoConnection")
        {
            Database.SetInitializer(new CargoInitializer());

          //  this.Configuration.LazyLoadingEnabled = true; 
        }

        // Veri tabanı oluşturulurken tablolara eklenen s takısını istemiyorsak bunu kullanmalıyız.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Users> User { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<UserAddresses> UserAddresses { get; set; }
        public DbSet<CargoStatus> CargoStatus { get; set; }
        public DbSet<CargoProcess> CargoProcess { get; set; }
    }
}