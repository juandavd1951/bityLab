using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace libBityLab.entidades
{
    public class VENTAS
    {
        public int id { get; set; }
        public int id_cliente { get; set; }
        public int id_sucursal { get; set; }
        public int id_promocion { get; set; }
        public DateTime fechaVenta { get; set; }
        public string estadoVenta { get; set; } = string.Empty;
        public decimal totalPagar { get; set; }
        public string direccionEnvio { get; set; } = string.Empty;
        [ForeignKey("id_cliente")] public CLIENTES? _CLIENTES { get; set; }
        [ForeignKey("id_sucursal")] public SUCURSALES? _SUCURSALES { get; set; }
        [ForeignKey("id_promocion")] public PROMOCIONES? _PROMOCIONES { get; set; }
        public List<PAGOS>? PAGOS { get; set; }
        public List<DEVOLUCIONES>? DEVOLUCIONES { get; set; }
        public List<ENVIOS>? ENVIOS { get; set; }
        public List<DETALLE_VENTAS>? DETALLE_VENTAS { get; set; }
    }

 
}
