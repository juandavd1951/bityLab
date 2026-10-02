using libBityLab.entidades;
using libBityLab.implementaciones;
using libBityLab.interfaces;
using Microsoft.EntityFrameworkCore;


namespace presentacion_mst
{
    [TestClass]
    public class testGARANTIAS
    {
        private IConexion conexion;
        private GARANTIAS? entidad = null;

        public testGARANTIAS()
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
            this.entidad = new GARANTIAS()
            {
                id_detalle_venta = 1,
                fechaSolicitud = DateTime.Now,
                motivoFalla = "Falla en el producto",
                estado = "Pendiente",
                resolucionTecnica = "Se reemplazó el producto defectuoso",
                fechaCierre = DateTime.Now

            };
            this.conexion.GARANTIAS!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.GARANTIAS!.ToList();
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
            this.entidad!.motivoFalla = "Falla en el producto actualizada";
            this.entidad!.estado = "Resuelto";
            this.entidad!.resolucionTecnica = "Se reemplazó el producto defectuoso";
            this.entidad!.fechaCierre = DateTime.Now;

            this.conexion.GARANTIAS!.Update(this.entidad!);
            this.conexion.SaveChanges();

        }
        private void Borrar()
        {
            this.conexion.GARANTIAS!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }


    }
}

