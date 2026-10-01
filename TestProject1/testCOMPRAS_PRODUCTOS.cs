using libBityLab.entidades;
using libBityLab.implementaciones;
using libBityLab.interfaces;
using Microsoft.EntityFrameworkCore;


namespace presentacion_mst
{
    [TestClass]
    public class testCOMPRAS_PRODUCTOS
    {
        private IConexion conexion;
        private COMPRAS_PRODUCTOS? entidad = null;

        public testCOMPRAS_PRODUCTOS()
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
            this.entidad = new COMPRAS_PRODUCTOS()
            {
                id_proveedor = 1,
                id_sucursal = 1,
                fechaOrden = DateTime.Now,
                estadoOrden = "Pendiente",
                totalEstimado = 100.00m,
                notasInternas = "Compra de prueba"



            };
            this.conexion.COMPRAS_PRODUCTOS!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.COMPRAS_PRODUCTOS!.ToList();
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
            this.entidad!.estadoOrden = "Completado";
            this.entidad!.totalEstimado = 150.00m;
            this.entidad!.notasInternas = "Compra actualizada";
            this.entidad!.fechaOrden = DateTime.Now;


            this.conexion.COMPRAS_PRODUCTOS!.Update(this.entidad!);
            this.conexion.SaveChanges();

        }
        private void Borrar()
        {
            this.conexion.COMPRAS_PRODUCTOS!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }


    }
}

