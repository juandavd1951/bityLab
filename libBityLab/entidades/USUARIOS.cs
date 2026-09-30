
using System.ComponentModel.DataAnnotations.Schema;
namespace libBityLab.entidades
{
    public class USUARIOS
    {
        public int id { get; set; }
        public int id_rol { get; set; }
        public string? nombre_completo_u { get; set; }
        public string? cedula { get; set; }
        public string? correo { get; set; }
        public string? contrasena { get; set; }
        public DateTime? fecha_registro { get; set; }
        [ForeignKey("ROLES")] public ROLES? _ROLES { get; set; }
        public List<CLIENTES>? CLIENTES { get; set; }
        public List<EMPLEADOS>? EMPLEADOS { get; set; }

    }

}


