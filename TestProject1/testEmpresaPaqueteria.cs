using libBityLab.entidades;
using libBityLab.implementaciones;
using libBityLab.interfaces;
using Microsoft.EntityFrameworkCore;


namespace presentacion_mst
{
    [TestClass]
    public class testEmpresaPaqueteria
    {
        private IConexion conexion;
        private EmpresaPaqueteria? entidad = null;

        public testEmpresaPaqueteria()
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
            this.entidad = new EmpresaPaqueteria()
            {
                telefono = "123456789",
                correoElectronico = "correo@example.com",
                NIT = "123456789",
                nombrePaqueteria = "Paqueteria S.A."

            };
            this.conexion.EmpresaPaqueteria!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.EmpresaPaqueteria!.ToList();
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
            this.entidad!.nombrePaqueteria = "Paqueteria Actualizada S.A.";
            this.entidad!.correoElectronico = "actualizado@example.com";
            this.entidad!.NIT = "987654321";
            this.entidad!.telefono = "987654321";


            this.conexion.EmpresaPaqueteria!.Update(this.entidad!);
            this.conexion.SaveChanges();

        }
        private void Borrar()
        {
            this.conexion.EmpresaPaqueteria!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }


    }
}

