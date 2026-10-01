using libBityLab.entidades;
using libBityLab.implementaciones;
using libBityLab.interfaces;
using Microsoft.EntityFrameworkCore;


namespace presentacion_mst
{
    [TestClass]
    public class testPROVEEDORES
    {
        private IConexion conexion;
        private PROVEEDORES? entidad = null;

        public testPROVEEDORES()
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
            this.entidad = new PROVEEDORES()
            {
                nombreContacto = "Juan Perez",
                nombreEmpresa = "Empresa XYZ",
                nitEmpresa = "123456789",
                telefonoPrincipal = "555-1234",
                correoVentas = "juan.perez@empresaxyz.com",
                direccionFisica = "Calle 123, Ciudad XYZ"

                
            };
            this.conexion.PROVEEDORES!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.PROVEEDORES!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        /*  private void Actualizar()
              public int id { get; set; }
        public string? nombre_empresa { get; set; }
        public string? nit_empresa { get; set; }
        public string? nombre_contacto { get; set; }
        public string? telefono_principal { get; set; }
        public string? correo_ventas { get; set; }
        public string? direccion_fisica { get; set; }
        */

        private void Actualizar()
        {
            this.entidad!.nombreEmpresa = "Empresa ABC";
            this.entidad!.nitEmpresa = "987654321";
            this.entidad!.nombreContacto = "Maria Lopez";
            this.entidad!.telefonoPrincipal = "555-5678";
            this.entidad!.correoVentas = "maria.lopez@empresabc.com";
            this.entidad!.direccionFisica = "Calle 456, Ciudad ABC";

            this.conexion.PROVEEDORES!.Update(this.entidad!);
            this.conexion.SaveChanges();

        }
        private void Borrar()
        {
            this.conexion.PROVEEDORES!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }


    }
}

