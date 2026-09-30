using libBityLab.entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace libBityLab.interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

        DbSet<ROLES>? ROLES { get; set; }
        DbSet<USUARIOS>? USUARIOS { get; set; }
        DbSet<MARCAS>? MARCAS { get; set; }
        DbSet<PRODUCTOS>? PRODUCTOS { get; set; }
        DbSet<COMPRAS_PRODUCTOS>? COMPRAS_PRODUCTOS { get; set; }
        DbSet<SUCURSALES>? SUCURSALES { get; set; }
        DbSet<PROVEEDORES>? PROVEEDORES { get; set; }
        DbSet<VENTAS>? VENTAS { get; set; }
        DbSet<DEVOLUCIONES>? DEVOLUCIONES { get; set; }
        DbSet<PAGOS>? PAGOS { get; set; }
        DbSet<METODOS_PAGO>? METODOS_PAGO { get; set; }
        DbSet<CLIENTES>? CLIENTES { get; set; }
        DbSet<PROMOCIONES>? PROMOCIONES { get; set; }
        DbSet<EmpresaPaqueteria>? EmpresaPaqueteria { get; set; }
        DbSet<ENVIOS>? ENVIOS { get; set; }
        DbSet<EMPLEADOS>? EMPLEADOS { get; set; }
        DbSet<INVENTARIOS>? INVENTARIOS { get; set; }
        DbSet<DETALLE_VENTAS>? DETALLE_VENTAS { get; set; }
        DbSet<DETALLES_ORDENES_COMPRAS>? DETALLES_ORDENES_COMPRAS { get; set; }
        DbSet<RESENAS>? RESENAS { get; set; }
        DbSet<GARANTIAS>? GARANTIAS { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}