using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace libBityLab.entidades
{
    public class GARANTIAS
    {
        public int id { get; set; }
        public int id_detalle_venta { get; set; }
        public DateTime fechaSolicitud { get; set; }
        public string? motivoFalla { get; set; }
        public string? estado { get; set; }
        public string? resolucionTecnica { get; set; }
        public DateTime fechaCierre { get; set; }
        [ForeignKey("id_detalle_venta")] public DETALLE_VENTAS? _DETALLE_VENTAS { get; set; }

    }
  
}
