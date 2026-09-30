
using libBityLab.entidades;
using libBityLab.interfaces;

using Microsoft.EntityFrameworkCore;

namespace libBityLab.implementaciones
{

    public class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        public DbSet<ROLES>? ROLES { get; set; }
        public DbSet<USUARIOS>? USUARIOS { get; set; }
        public DbSet<MARCAS>? MARCAS { get; set; }
        public DbSet<PRODUCTOS>? PRODUCTOS { get; set; }
        public DbSet<COMPRAS_PRODUCTOS>? COMPRAS_PRODUCTOS { get; set; }
        public DbSet<SUCURSALES>? SUCURSALES { get; set; }
        public DbSet<PROVEEDORES>? PROVEEDORES { get; set; }
        public DbSet<VENTAS>? VENTAS { get; set; }
        public DbSet<DEVOLUCIONES>? DEVOLUCIONES { get; set; }
        public DbSet<PAGOS>? PAGOS { get; set; }
        public DbSet<METODOS_PAGO>? METODOS_PAGO { get; set; }
        public DbSet<CLIENTES>? CLIENTES { get; set; }
        public DbSet<PROMOCIONES>? PROMOCIONES { get; set; }
        public DbSet<EmpresaPaqueteria>? EmpresaPaqueteria { get; set; }
        public DbSet<ENVIOS>? ENVIOS { get; set; }
        public DbSet<EMPLEADOS>? EMPLEADOS { get; set; }
        public DbSet<INVENTARIOS>? INVENTARIOS { get; set; }
        public DbSet<DETALLE_VENTAS>? DETALLE_VENTAS { get; set; }
        public DbSet<DETALLES_ORDENES_COMPRAS>? DETALLES_ORDENES_COMPRAS { get; set; }
        public DbSet<RESENAS>? RESENAS { get; set; }
        public DbSet<GARANTIAS>? GARANTIAS { get; set; }

    }
}