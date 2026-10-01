using libBityLab.entidades;
using libBityLab.implementaciones;
using libBityLab.interfaces;
using Microsoft.EntityFrameworkCore;


namespace presentacion_mst
{
    [TestClass]
    public class testVENTAS
    {
        private IConexion conexion;
        private VENTAS? entidad = null;

        public testVENTAS()
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
            this.entidad = new VENTAS()
            {
                id_cliente = 1,
                id_sucursal = 1,
                id_promocion = 1,
                fechaVenta = DateTime.Now,
                estadoVenta = "Pendiente",
                totalPagar = 1000.00m,
                direccionEnvio = "Calle Falsa 123"


            };
            this.conexion.VENTAS!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.VENTAS!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        /*  private void Actualizar()
        public int id { get; set; }
        public int id_cliente { get; set; }
        public int id_sucursal { get; set; }
        public int id_promocion { get; set; }
        public DateTime fecha_venta { get; set; }
        public string estado_venta { get; set; } = string.Empty;
        public decimal total_pagar { get; set; }
        public string direccion_envio { get; set; } = string.Empty;
       
        */

        private void Actualizar()
        {
            this.entidad!.id_cliente = 1;
            this.entidad!.id_sucursal = 1;
            this.entidad!.id_promocion = 1;
            this.entidad!.fechaVenta = DateTime.Now;
            this.entidad!.estadoVenta = "Completada";
            this.entidad!.totalPagar = 1500.00m;
            this.entidad!.direccionEnvio = "Calle Verdadera 456";
            this.conexion.VENTAS!.Update(this.entidad!);
            this.conexion.SaveChanges();

        }
        private void Borrar()
        {
            this.conexion.VENTAS!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }


    }
}

