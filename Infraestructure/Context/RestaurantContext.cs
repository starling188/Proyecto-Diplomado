

using Domain.Entities;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Context
{
    public class RestaurantContext : DbContext
    {

        public RestaurantContext(DbContextOptions<RestaurantContext> options)
        : base(options)
        {
        }



        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetallePedido> DetallesPedido { get; set; }
        public DbSet<Factura> Facturas { get; set; }





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Pedido>()
                  .HasMany(p => p.DetallesPedido)
                  .WithOne(dp => dp.Pedido)
                  .HasForeignKey(dp => dp.IdPedido);

            modelBuilder.Entity<DetallePedido>()
                .HasOne(dp => dp.Menu)
                .WithMany()
                .HasForeignKey(dp => dp.IdPlato);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Cliente)
                .WithMany()
                .HasForeignKey(p => p.IdCliente);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Mesa)
                .WithMany()
                .HasForeignKey(p => p.IdMesa);

            modelBuilder.Entity<Factura>()
                .HasOne(f => f.Pedido)
                .WithMany()
                .HasForeignKey(f => f.IdPedido);

          
        }



    }
}
