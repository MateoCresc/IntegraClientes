using ClienteApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ClienteApp.Data.DbContexts
{
    public class ClienteAppDBContext : DbContext
    {
        public ClienteAppDBContext() : base("DefaultConnection")  {

        
        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>().ToTable("Cliente").HasKey(c => c.Cuit);

        }
    }
}
