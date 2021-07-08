using API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Context
{
    public class APIContext : DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Producto> Productos { get; set; }

        public DbSet<DetalleOrden> DetallesOrdenes { get; set; }

        // The following configures EF to create a Sqlite database file as `C:\blogging.db`.
        // For Mac or Linux, change this to `/tmp/blogging.db` or any other absolute path.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=C:\Temp\Parrot\ParrotChallenge.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orden>()
                .Property(b => b.Fecha)
                .HasDefaultValueSql("date('now')");

            
    
        }
    }
}
