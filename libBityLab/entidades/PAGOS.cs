using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace libBityLab.entidades
{
    public class PAGOS
    {
        public int id { get; set; }
        public int id_venta { get; set; }
        public int id_metodo_pago { get; set; }
        public decimal monto_pagado { get; set; }
        public DateTime fecha_pago { get; set; }
        public string estado_transaccion { get; set; } = string.Empty;
        public string referencia_pasarela { get; set; } = string.Empty;
        [ForeignKey("VENTAS")] public VENTAS? _VENTAS { get; set; }
        [ForeignKey("METODOS_PAGO")] public METODOS_PAGO? _METODOS_PAGO { get; set; }
    }

}
