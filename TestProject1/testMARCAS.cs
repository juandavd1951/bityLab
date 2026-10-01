using libBityLab.entidades;
using libBityLab.implementaciones;
using libBityLab.interfaces;
using Microsoft.EntityFrameworkCore;


namespace presentacion_mst
{
    [TestClass]
    public class testMARCAS
    {
        private IConexion conexion;
        private MARCAS? entidad = null;

        public testMARCAS()
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
            this.entidad = new MARCAS()
            {
                nombre = "ficico",
                sitioWeb = "www.ficico.com",
                correoSoporte = "soporte@ficico.com",
                telefonoContacto = "123-456-7890"

            };
            this.conexion.MARCAS!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.MARCAS!.ToList();
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
            this.entidad!.nombre = "ficico actualizado";
            this.entidad!.sitioWeb = "www.ficicoactualizado.com";
            this.entidad!.correoSoporte = "soporte@ficicoactualizado.com";
            this.entidad!.telefonoContacto = "098-765-4321";

            this.conexion.MARCAS!.Update(this.entidad!);
            this.conexion.SaveChanges();

        }
        private void Borrar()
        {
            this.conexion.MARCAS!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }


    }
}

