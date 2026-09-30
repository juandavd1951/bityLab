using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace libBityLab.entidades
{
    public class CLIENTES
    {
        public int id { get; set; }
        public int id_usuario { get; set; }
        public string nombre_completo_C { get; set; } = string.Empty;
        public string telefono { get; set; } = string.Empty;
        public string direccion_principal { get; set; } = string.Empty;
        public DateTime fecha_nacimiento { get; set; }
        [ForeignKey("USUARIOS")] public USUARIOS? _USUARIOS { get; set; }
        public List<VENTAS>? VENTAS { get; set; }
    }


}
