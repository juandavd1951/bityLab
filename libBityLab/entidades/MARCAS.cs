
using System.ComponentModel.DataAnnotations.Schema;


namespace libBityLab.entidades
{
    public class MARCAS
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public string? sitio_web { get; set; }
        public string? correo_soporte { get; set; }
        public string? telefono_contacto { get; set; }
        public List<PRODUCTOS>? PRODUCTOS { get; set; }

    }

 
}
