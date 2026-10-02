using libBityLab.entidades;
using libBityLab.implementaciones;
using libBityLab.interfaces;
using Microsoft.EntityFrameworkCore;


namespace presentacion_mst
{
    [TestClass]
    public class testINVENTARIOS
    {
        private IConexion conexion;
        private INVENTARIOS? entidad = null;

        public testINVENTARIOS()
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
            this.entidad = new INVENTARIOS()
            {
                id_producto = 1,
                id_sucursal = 1,
                cantidadDisponible = 100,
                stockMinimo = 10,
                estanteriaUbicacion = "A1",
                ultimaActualizacion = DateTime.Now,
                capacidadBodega = 500


            };
            this.conexion.INVENTARIOS!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.INVENTARIOS!.ToList();
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
            this.entidad!.cantidadDisponible = 200;
            this.entidad!.stockMinimo = 20;
            this.entidad!.estanteriaUbicacion = "B2";
            this.entidad!.ultimaActualizacion = DateTime.Now;
            this.entidad!.capacidadBodega = 600;

            this.conexion.INVENTARIOS!.Update(this.entidad!);
            this.conexion.SaveChanges();

        }
        private void Borrar()
        {
            this.conexion.INVENTARIOS!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }


    }
}

