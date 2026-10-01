using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace libBityLab.entidades
{
    public class DEVOLUCIONES
    {
        public int id { get; set; }
        public int id_venta { get; set; }
        public int id_metodo_pago_reembolso { get; set; }
        public DateTime fechaSolicitud { get; set; }
        public string motivo { get; set; } = string.Empty;
        public string estadoProceso { get; set; } = string.Empty;
        public decimal montoReembolsado { get; set; }
        [ForeignKey("id_metodo_pago_reembolso")] public METODOS_PAGO? _METODOS_PAGO { get; set; }
        [ForeignKey("id_venta")] public VENTAS? _VENTAS { get; set; }
    }

}
