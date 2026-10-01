using libBityLab.entidades;
using libBityLab.implementaciones;
using libBityLab.interfaces;
using Microsoft.EntityFrameworkCore;


namespace presentacion_mst
{
    [TestClass]
    public class testENVIOS
    {
        private IConexion conexion;
        private ENVIOS? entidad = null;

        public testENVIOS()
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
            this.entidad = new ENVIOS()
            {
                id_empresa_paqueteria = 1,
                id_venta = 1,
                numeroGuia = "123456789",
                estado = "En tránsito",
                fechaEstimadaEntrega = DateTime.Now.AddDays(5),
                fechaEntregaReal = DateTime.Now.AddDays(5),
                costo = 100.50m


            };
            this.conexion.ENVIOS!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.ENVIOS!.ToList();
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
            this.entidad!.estado = "Entregado";
            this.entidad!.fechaEntregaReal = DateTime.Now;
            this.entidad!.costo = 120.75m;
            this.entidad!.numeroGuia = "987654321";
            this.entidad!.fechaEstimadaEntrega = DateTime.Now.AddDays(3);
           

            this.conexion.ENVIOS!.Update(this.entidad!);
            this.conexion.SaveChanges();

        }
        private void Borrar()
        {
            this.conexion.ENVIOS!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }


    }
}

