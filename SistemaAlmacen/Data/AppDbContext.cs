using Microsoft.EntityFrameworkCore;
using SistemaAlmacen.Model;

namespace SistemaAlmacen.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> db) : base(db)
        {
            
        }
        //tablas 
        public DbSet<Usuario> Usuarios { get; set ;}
        public DbSet<Credenciales> Credenciales { get; set; }
        public DbSet<Camion> Camions { get; set; }
        public DbSet<RolesDetalle> RolesDetalles { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetallePedido> DetallePedidos { get; set; }
        public DbSet<Despacho> Despachos { get; set; }
        public DbSet<DetalleDespacho> DetalleDespachos { get; set; }

        //declarar mis llaves foraneas y primarias

        protected override void OnModelCreating(ModelBuilder db)
        {
            //tabla usuario
            db.Entity<Usuario>(X =>
            {
                X.HasKey(x=>x.IdUsuario);
            });
            //tabla credenciales
            db.Entity<Credenciales>(X =>
            {
                X.HasKey(x => x.IdCredenciales);
                X.HasOne(p=>p.Usuario).WithMany().HasForeignKey(p=>p.IdUsuario).OnDelete(DeleteBehavior.Cascade);
            });

            //tabla Roles
            db.Entity<Roles>(X =>
            {
                X.HasKey(x => x.IdRoles);
            });

            //tabla Detalle roles
            db.Entity<RolesDetalle>(X =>
            {
                X.HasKey(x => x.IdRolesDetalle);
                X.HasOne(p => p.Usuario).WithMany().HasForeignKey(p => p.IdUsuario).OnDelete(DeleteBehavior.Cascade);
                X.HasOne(p => p.Roles).WithMany().HasForeignKey(p => p.IdRoles).OnDelete(DeleteBehavior.Cascade);
            });


            //tabla CAmion
            db.Entity<Camion>(X =>
            {
                X.HasKey(x => x.IdCamion);
                X.HasOne(p => p.Usuario).WithMany().HasForeignKey(p => p.IdUsuario).OnDelete(DeleteBehavior.Cascade);
            });


            //tabla Categoria
            db.Entity<Categoria>(X =>
            {
                X.HasKey(x => x.IdCategoria);
            });

            //tabla producto
            db.Entity<Producto>(X =>
            {
                X.HasKey(x => x.IdProducto);
                X.HasOne(p => p.Categoria).WithMany().HasForeignKey(p => p.IdCategoria).OnDelete(DeleteBehavior.Cascade);
            });


            //tabla Pedido
            db.Entity<Pedido>(X =>
            {
                X.HasKey(x => x.IdPedido);
                X.HasOne(p => p.Usuario).WithMany().HasForeignKey(p => p.IdUsuario).OnDelete(DeleteBehavior.Cascade);
            });


            //tabla Detalle Pedidos
            db.Entity<DetallePedido>(X =>
            {
                X.HasKey(x => x.IdDetallePedido);
                X.HasOne(p => p.Pedido).WithMany().HasForeignKey(p => p.IdPedido).OnDelete(DeleteBehavior.Cascade);
                X.HasOne(p => p.Producto).WithMany().HasForeignKey(p => p.IdProducto).OnDelete(DeleteBehavior.Cascade);
            });

            //tabla Despacho
            db.Entity<Despacho>(X =>
            {
                X.HasKey(x => x.IdDespacho);
                X.HasOne(p => p.Camion).WithMany().HasForeignKey(p => p.IdCamion).OnDelete(DeleteBehavior.Cascade);
            });

            //tabla Detalle despacho
            db.Entity<DetalleDespacho>(X =>
            {
                X.HasKey(x => x.IdDetalleDespacho);
                X.HasOne(p => p.Despacho).WithMany().HasForeignKey(p => p.IdDespacho).OnDelete(DeleteBehavior.NoAction);
                X.HasOne(p => p.Pedido).WithMany().HasForeignKey(p => p.IdPedido).OnDelete(DeleteBehavior.NoAction);
            });










        }









    }
}
