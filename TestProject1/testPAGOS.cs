using libBityLab.entidades;
using libBityLab.implementaciones;
using libBityLab.interfaces;
using Microsoft.EntityFrameworkCore;


namespace presentacion_mst
{
    [TestClass]
    public class testPAGOS
    {
        private IConexion conexion;
        private PAGOS? entidad = null;

        public testPAGOS()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = "server=localhost;database=BityLab;Integrated Security=True;TrustServerCertificate=true;";
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
            this.entidad = new PAGOS()
            {
                id_metodo_pago = 1,
                id_venta = 1,
                montoPagado = 99.99m,
                fechaPago = DateTime.Now,
                estadoTransaccion = "Completado",
                referenciaPasarela = "REF123456789",


            };
            this.conexion.PAGOS!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.PAGOS!.ToList();
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
            this.entidad!.estadoTransaccion = "Pendiente";
            this.entidad!.montoPagado = 199.99m;
            this.entidad!.referenciaPasarela = "REF987654321";
            this.entidad!.fechaPago = DateTime.Now.AddDays(1);


            this.conexion.PAGOS!.Update(this.entidad!);
            this.conexion.SaveChanges();

        }
        private void Borrar()
        {
            this.conexion.PAGOS!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }


    }
}

