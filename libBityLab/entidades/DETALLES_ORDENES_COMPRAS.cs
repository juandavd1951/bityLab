using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace libBityLab.entidades
{
    public class DETALLES_ORDENES_COMPRAS
    {
        public int id { get; set; }
        public int id_compras_producto { get; set; }
        public int id_producto { get; set; }
        public int cantidad_solicitada { get; set; }
        public decimal costo_unitario { get; set; }
        public decimal subtotal_costo { get; set; }
        [ForeignKey("COMPRAS_PRODUCTOS")] public COMPRAS_PRODUCTOS? _COMPRAS_PRODUCTOS { get; set; }
        [ForeignKey("PRODUCTOS")] public PRODUCTOS? _PRODUCTOS { get; set; }
    }

}
