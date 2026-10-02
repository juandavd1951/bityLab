using libBityLab.entidades;
using libBityLab.implementaciones;
using libBityLab.interfaces;
using Microsoft.EntityFrameworkCore;


namespace presentacion_mst
{
    [TestClass]
    public class testMETODOS_PAGO
    {
        private IConexion conexion;
        private METODOS_PAGO? entidad = null;

        public testMETODOS_PAGO()
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
            this.entidad = new METODOS_PAGO()
            {
                nombre = "Tarjeta de Crédito",
                descripcion = "Pago mediante tarjeta de crédito"


            };
            this.conexion.METODOS_PAGO!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.METODOS_PAGO!.ToList();
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
            this.entidad!.descripcion = "Pago mediante ficico";
            this.entidad!.nombre = "ficico";


            this.conexion.METODOS_PAGO!.Update(this.entidad!);
            this.conexion.SaveChanges();

        }
        private void Borrar()
        {
            this.conexion.METODOS_PAGO!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }


    }
}

