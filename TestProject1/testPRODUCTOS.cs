using libBityLab.entidades;
using libBityLab.implementaciones;
using libBityLab.interfaces;
using Microsoft.EntityFrameworkCore;


namespace presentacion_mst
{
    [TestClass]
    public class testPRODUCTOS
    {
        private IConexion conexion;
        private PRODUCTOS? entidad = null;

        public testPRODUCTOS()
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
            this.entidad = new PRODUCTOS()
            {
                id_marca = 1,
                categoria = 1,
                nombreProducto = "Producto de prueba",
                descripcionLarga = "Este es un producto de prueba para la clase testPRODUCTOS",
                precioVenta = 99.99m,
                NumeroSerie = "SN123456789",
                modelo = "Modelo de prueba",
                especificacionesTecnicas = "Especificaciones técnicas de prueba"




            };
            this.conexion.PRODUCTOS!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.PRODUCTOS!.ToList();
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
       this.entidad!.descripcionLarga = "Este es un producto de prueba actualizado para la clase testPRODUCTOS";
            this.entidad!.precioVenta = 149.99m;
            this.entidad!.NumeroSerie = "SN987654321";
            this.entidad!.modelo = "Modelo de prueba actualizado";
            this.entidad!.especificacionesTecnicas = "Especificaciones técnicas de prueba actualizadas";
            this.entidad!.nombreProducto = "Producto de prueba actualizado";
            this.entidad!.categoria = 2;
          
      




            this.conexion.PRODUCTOS!.Update(this.entidad!);
            this.conexion.SaveChanges();

        }
        private void Borrar()
        {
            this.conexion.PRODUCTOS!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }


    }
}

