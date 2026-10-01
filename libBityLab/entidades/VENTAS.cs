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
        public DateTime fecha_venta { get; set; }
        public string estado_venta { get; set; } = string.Empty;
        public decimal total_pagar { get; set; }
        public string direccion_envio { get; set; } = string.Empty;
        [ForeignKey("id_cliente")] public CLIENTES? _CLIENTES { get; set; }
        [ForeignKey("id_sucursal")] public SUCURSALES? _SUCURSALES { get; set; }
        [ForeignKey("id_promocion")] public PROMOCIONES? _PROMOCIONES { get; set; }
        public List<PAGOS>? PAGOS { get; set; }
        public List<DEVOLUCIONES>? DEVOLUCIONES { get; set; }
        public List<ENVIOS>? ENVIOS { get; set; }
        public List<DETALLE_VENTAS>? DETALLE_VENTAS { get; set; }
    }

 
}
