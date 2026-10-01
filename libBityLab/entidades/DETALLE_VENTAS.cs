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
        public decimal precioUnitarioVenta { get; set; }
        public decimal descuentoAplicado { get; set; }
        public decimal subtotal { get; set; }
        [ForeignKey("id_venta")] public VENTAS? _VENTAS { get; set; }
        [ForeignKey("id_producto")] public PRODUCTOS? _PRODUCTOS { get; set; }
        public List<GARANTIAS>? GARANTIAS { get; set; }

    }

}
