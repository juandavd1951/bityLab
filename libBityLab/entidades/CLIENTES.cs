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
        public string nombreCompletoC { get; set; } = string.Empty;
        public string telefono { get; set; } = string.Empty;
        public string direccionPrincipal { get; set; } = string.Empty;
        public DateTime fechaNacimiento { get; set; }
        [ForeignKey("id_usuario")] public USUARIOS? _USUARIOS { get; set; }
        public List<VENTAS>? VENTAS { get; set; }
    }


}
