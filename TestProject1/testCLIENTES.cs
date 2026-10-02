using libBityLab.entidades;
using libBityLab.implementaciones;
using libBityLab.interfaces;
using Microsoft.EntityFrameworkCore;


namespace presentacion_mst
{
    [TestClass]
    public class testCLIENTES
    {
        private IConexion conexion;
        private CLIENTES? entidad = null;

        public testCLIENTES()
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
            this.entidad = new CLIENTES()
            {
                id_usuario = 1,
                nombreCompletoC = "Juan Perez",
                telefono = "123456789",
                direccionPrincipal = "Calle Falsa 123",
                fechaNacimiento = new DateTime(1990, 1, 1)



            };
            this.conexion.CLIENTES!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.CLIENTES!.ToList();
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
            this.entidad!.nombreCompletoC = "Juan Perez Actualizado";
            this.entidad!.telefono = "987654321";
            this.entidad!.direccionPrincipal = "Avenida Siempre Viva 456";
            this.entidad!.fechaNacimiento = new DateTime(1999, 2, 5);


            this.conexion.CLIENTES!.Update(this.entidad!);
            this.conexion.SaveChanges();

        }
        private void Borrar()
        {
            this.conexion.CLIENTES!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }


    }
}

