using libBityLab.entidades;
using libBityLab.implementaciones;
using libBityLab.interfaces;
using Microsoft.EntityFrameworkCore;


namespace presentacion_mst
{
    [TestClass]
    public class testDETALLE_VENTAS
    {
        private IConexion conexion;
        private DETALLE_VENTAS? entidad = null;

        public testDETALLE_VENTAS()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = "server=kuskuruma;database=BityLab;Integrated Security=True;TrustServerCertificate=true;";
        }

        [TestMethod]
        public void Execute()
        {
            Insertar();
            Consultar();
            Actualizar();
            Borrar();
        }

        public void Insertar()
        {
            this.entidad = new DETALLE_VENTAS()
            {
                id_venta = 1,
                id_producto = 1,
                cantidad = 20,
                precioUnitarioVenta = 12.75m,
                descuentoAplicado = 0.00m,
                subtotal = 255.00m



            };
            this.conexion.DETALLE_VENTAS!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.DETALLE_VENTAS!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        /*  
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    codigoCupon NVARCHAR(50),
    descripcion NVARCHAR(255),
    porcentajeDescuento DECIMAL(5, 2),
    fechaInicio DATETIME,
    fechaFin DATETIME
        */

        private void Actualizar()
        {
            this.entidad!.cantidad = 25;
            this.entidad!.precioUnitarioVenta = 10.00m;
            this.entidad!.descuentoAplicado = 5.00m;
            this.entidad!.subtotal = 250.00m;


            this.conexion.DETALLE_VENTAS!.Update(this.entidad!);
            this.conexion.SaveChanges();

        }
        private void Borrar()
        {
            this.conexion.DETALLE_VENTAS!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }


    }
}

