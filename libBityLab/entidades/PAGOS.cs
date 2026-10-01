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
        public decimal montoPagado { get; set; }
        public DateTime fechaPago { get; set; }
        public string estadoTransaccion { get; set; } = string.Empty;
        public string referenciaPasarela { get; set; } = string.Empty;
        [ForeignKey("id_venta")] public VENTAS? _VENTAS { get; set; }
        [ForeignKey("id_metodo_pago")] public METODOS_PAGO? _METODOS_PAGO { get; set; }
    }

}
