using libBityLab.entidades;
using libBityLab.implementaciones;
using libBityLab.interfaces;
using Microsoft.EntityFrameworkCore;


namespace presentacion_mst
{
    [TestClass]
    public class testEMPLEADOS
    {
        private IConexion conexion;
        private EMPLEADOS? entidad = null;

        public testEMPLEADOS()
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
            this.entidad = new EMPLEADOS()
            {
                id_usuario = 1,
                id_sucursal = 1,
                cargopuesto = "Gerente de Ventas",
                salario = 50000.00m,
                fechaContratacion = DateTime.Now


            };
            this.conexion.EMPLEADOS!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.EMPLEADOS!.ToList();
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
            this.entidad!.cargopuesto = "Gerente de Marketing";
            this.entidad!.salario = 60000.00m;
            this.entidad!.fechaContratacion = DateTime.Now;


            this.conexion.EMPLEADOS!.Update(this.entidad!);
            this.conexion.SaveChanges();

        }
        private void Borrar()
        {
            this.conexion.EMPLEADOS!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }


    }
}

