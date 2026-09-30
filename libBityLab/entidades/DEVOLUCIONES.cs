using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace libBityLab.entidades
{
    public class DEVOLUCIONES
    {
        public int id { get; set; }
        public int id_VENTAS { get; set; }
        public int id_metodo_pago_reembolso { get; set; }
        public DateTime fecha_solicitud { get; set; }
        public string motivo { get; set; } = string.Empty;
        public string estado_proceso { get; set; } = string.Empty;
        public decimal monto_reembolsado { get; set; }
        [ForeignKey("METODOS_PAGO")] public METODOS_PAGO? _METODOS_PAGO { get; set; }
        [ForeignKey("VENTAS")] public VENTAS? _VENTAS { get; set; }
    }

}
