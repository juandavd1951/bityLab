using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace libBityLab.entidades
{
    public class DETALLE_VENTAS
    {
        public int id { get; set; }
        public int id_venta { get; set; }
        public int id_producto { get; set; }
        public int cantidad { get; set; }
        public decimal precio_unitario_venta { get; set; }
        public decimal descuento_aplicado { get; set; }
        public decimal subtotal { get; set; }
        [ForeignKey("VENTAS")] public VENTAS? _VENTAS { get; set; }
        [ForeignKey("PRODUCTOS")] public PRODUCTOS? _PRODUCTOS { get; set; }
        public List<GARANTIAS>? GARANTIAS { get; set; }

    }

}
