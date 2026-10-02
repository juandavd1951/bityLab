using libBityLab.entidades;
using libBityLab.implementaciones;
using libBityLab.interfaces;
using Microsoft.EntityFrameworkCore;


namespace presentacion_mst
{
    [TestClass]
    public class testPROMOCIONES
    {
        private IConexion conexion;
        private PROMOCIONES? entidad = null;

        public testPROMOCIONES()
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
            this.entidad = new PROMOCIONES()
            {
                codigoCupon = "PROMO123",
                descripcion = "Descuento del 20% en todos los productos",
                porcentajeDescuento = 20.0m,
                fechaInicio = DateTime.Now,
                fechaFin = DateTime.Now.AddDays(30)



            };
            this.conexion.PROMOCIONES!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.PROMOCIONES!.ToList();
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
        this.entidad!.descripcion = "Descuento del 25% en todos los productos";
            this.entidad!.porcentajeDescuento = 25.0m;
            this.entidad!.fechaFin = DateTime.Now.AddDays(60);
            this.entidad!.codigoCupon = "PROMO456";
            this.entidad!.fechaInicio = DateTime.Now.AddDays(-5);

           

            this.conexion.PROMOCIONES!.Update(this.entidad!);
            this.conexion.SaveChanges();

        }
        private void Borrar()
        {
            this.conexion.PROMOCIONES!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }


    }
}

