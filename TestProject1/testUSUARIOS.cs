using libBityLab.entidades;
using libBityLab.implementaciones;
using libBityLab.interfaces;
using Microsoft.EntityFrameworkCore;


namespace presentacion_mst
{
    [TestClass]
    public class testUSUARIOS
    {
        private IConexion conexion;
        private USUARIOS? entidad = null;

        public testUSUARIOS()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = "server=localhost;database=BityLab;Integrated Security=True;TrustServerCertificate=true;";
        }

        [TestMethod]
        public void Execute()
        {
            Insertar();
            Consultar();
            //Actualizar();
            Borrar();
        }

        public void Insertar()
        {
            this.entidad = new USUARIOS()
            {
                nombre_completo_u = "Juan Perez",
                cedula = "1234567890",
                correo = "juan.perez@example.com",
                contrasena = "password123",
                fecha_registro = DateTime.Now,  
            };
            this.conexion.USUARIOS!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.USUARIOS!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        /*  private void Actualizar()
          {
              this.entidad!.Activo = false;

              var entry = this.conexion!.Entry<USUARIOS>(this.entidad);
              entry.State = EntityState.Modified;
              this.conexion!.SaveChanges();
          }
        */
        private void Borrar()
        {
            this.conexion.USUARIOS!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

