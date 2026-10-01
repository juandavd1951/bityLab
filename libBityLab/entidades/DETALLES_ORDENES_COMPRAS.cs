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
        public int cantidadSolicitada { get; set; }
        public decimal costoUnitario { get; set; }
        public decimal subtotalCosto { get; set; }
        [ForeignKey("id_compras_producto")] public COMPRAS_PRODUCTOS? _COMPRAS_PRODUCTOS { get; set; }
        [ForeignKey("id_producto")] public PRODUCTOS? _PRODUCTOS { get; set; }
    }

}
