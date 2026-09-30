using libBityLab.entidades;
using libBityLab.implementaciones;
using libBityLab.interfaces;
using Microsoft.EntityFrameworkCore;


namespace presentacion_mst
{
    [TestClass]
    public class testROLES
    {
        private IConexion conexion;
        private ROLES? entidad = null;

        public testROLES()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = "server=kuskuruma;database=BityLab;Integrated Security=True;TrustServerCertificate=true;";
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
            this.entidad = new ROLES()
            {
              
                nombre = "juan david cano",
                descripcion = "Profesional en todo",
                salario_estimado = 10000,
            };
            this.conexion.ROLES!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.ROLES!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        /*  private void Actualizar()
          {
              this.entidad!.Activo = false;

              var entry = this.conexion!.Entry<ROLES>(this.entidad);
              entry.State = EntityState.Modified;
              this.conexion!.SaveChanges();
          }
        */
        private void Borrar()
        {
            this.conexion.ROLES!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

