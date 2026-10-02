using libBityLab.entidades;
using libBityLab.implementaciones;
using libBityLab.interfaces;
using Microsoft.EntityFrameworkCore;


namespace presentacion_mst
{
    [TestClass]
    public class testDEVOLUCIONES
    {
        private IConexion conexion;
        private DEVOLUCIONES? entidad = null;

        public testDEVOLUCIONES()
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
            this.entidad = new DEVOLUCIONES()
            {
                id_metodo_pago_reembolso = 1,
                id_venta = 1,
                fechaSolicitud = DateTime.Now,
                motivo = "Producto defectuoso",
                estadoProceso = "Pendiente",
                montoReembolsado = 100.00m

            };
            this.conexion.DEVOLUCIONES!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.DEVOLUCIONES!.ToList();
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
            this.entidad!.motivo = "Producto defectuoso - Actualizado";
            this.entidad!.estadoProceso = "Aprobado";
            this.entidad!.montoReembolsado = 150.00m;
            this.entidad!.fechaSolicitud = DateTime.Now;


            this.conexion.DEVOLUCIONES!.Update(this.entidad!);
            this.conexion.SaveChanges();

        }
        private void Borrar()
        {
            this.conexion.DEVOLUCIONES!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }


    }
}

