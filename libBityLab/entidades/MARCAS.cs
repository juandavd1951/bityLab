
using System.ComponentModel.DataAnnotations.Schema;


namespace libBityLab.entidades
{
    public class MARCAS
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public string? sitioWeb { get; set; }
        public string? correoSoporte { get; set; }
        public string? telefonoContacto { get; set; }
        public List<PRODUCTOS>? PRODUCTOS { get; set; }

    }

 
}
