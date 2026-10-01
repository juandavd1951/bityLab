using libBityLab.entidades;
using libBityLab.implementaciones;
using libBityLab.interfaces;
using Microsoft.EntityFrameworkCore;


namespace presentacion_mst
{
    [TestClass]
    public class testDETALLES_ORDENES_COMPRAS
    {
        private IConexion conexion;
        private DETALLES_ORDENES_COMPRAS? entidad = null;

        public testDETALLES_ORDENES_COMPRAS()
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
            this.entidad = new DETALLES_ORDENES_COMPRAS()
            {
                id_compras_producto = 1,
                id_producto = 1,
                cantidadSolicitada = 10,
                costoUnitario = 15.50m,
                subtotalCosto = 155.00m


            };
            this.conexion.DETALLES_ORDENES_COMPRAS!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.DETALLES_ORDENES_COMPRAS!.ToList();
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
            this.entidad!.cantidadSolicitada = 20;
            this.entidad!.costoUnitario = 12.75m;
            this.entidad!.subtotalCosto = 255.00m;


            this.conexion.DETALLES_ORDENES_COMPRAS!.Update(this.entidad!);
            this.conexion.SaveChanges();

        }
        private void Borrar()
        {
            this.conexion.DETALLES_ORDENES_COMPRAS!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }


    }
}

