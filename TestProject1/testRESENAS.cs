using libBityLab.entidades;
using libBityLab.implementaciones;
using libBityLab.interfaces;
using Microsoft.EntityFrameworkCore;


namespace presentacion_mst
{
    [TestClass]
    public class testRESENAS
    {
        private IConexion conexion;
        private RESENAS? entidad = null;

        public testRESENAS()
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
            this.entidad = new RESENAS()
            {
                id_producto = 1,
                id_cliente = 1,
                calificacion_estrellas = 5,
                comentario = "Excelente producto",
                fecha_publicacion = DateTime.Now


            };
            this.conexion.RESENAS!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.RESENAS!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        /*  private void Actualizar()
        public int id { get; set; }
        public int id_producto { get; set; }
        public int id_produto { get; set; }
        public int id_cliente { get; set; }
        public int calificacion_estrellas { get; set; }
        public string? comentario { get; set; }
        public DateTime fecha_publicacion { get; set; }
        */

        private void Actualizar()
        {
            this.entidad!.calificacion_estrellas = 4;
            this.entidad!.comentario = "Buen producto, pero podría mejorar";
            this.entidad!.fecha_publicacion = DateTime.Now;

            this.conexion.RESENAS!.Update(this.entidad!);
            this.conexion.SaveChanges();

        }
        private void Borrar()
        {
            this.conexion.RESENAS!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }


    }
}

