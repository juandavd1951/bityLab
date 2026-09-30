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
        public DateTime fecha_solicitud { get; set; }
        public string? motivo_falla { get; set; }
        public string? estado { get; set; }
        public string? resolucion_tecnica { get; set; }
        public DateTime fecha_cierre { get; set; }
        [ForeignKey("DETALLE_VENTAS")] public DETALLE_VENTAS? _DETALLE_VENTAS { get; set; }

    }
  
}
