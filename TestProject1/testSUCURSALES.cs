using libBityLab.entidades;
using libBityLab.implementaciones;
using libBityLab.interfaces;
using Microsoft.EntityFrameworkCore;


namespace presentacion_mst
{
    [TestClass]
    public class testSUCURSALES
    {
        private IConexion conexion;
        private SUCURSALES? entidad = null;

        public testSUCURSALES()
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
            this.entidad = new SUCURSALES()
            {
                nombre = "Sucursal 1",
                direccion = "Calle 123",
                ciudad = "Ciudad 1",
                telefonoContacto = "123456789",
                horarioAtencion = "9:00 AM - 6:00 PM"


            };
            this.conexion.SUCURSALES!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.SUCURSALES!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        /*  public int id { get; set; }
        public string? nombre { get; set; }
        public string? direccion { get; set; }
        public string? ciudad { get; set; }
        public string? telefono_contacto { get; set; }
        public string? horario_atencion { get; set; }
        */

        private void Actualizar()
        {
            this.entidad!.nombre = "Sucursal 1 Actualizada";
            this.entidad!.direccion = "Calle 456";
            this.entidad!.ciudad = "Ciudad 2";
            this.entidad!.telefonoContacto = "987654321";
            this.entidad!.horarioAtencion = "10:00 AM - 7:00 PM";

            this.conexion.SUCURSALES!.Update(this.entidad!);
            this.conexion.SaveChanges();

        }
        private void Borrar()
        {
            this.conexion.SUCURSALES!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }


    }
}

