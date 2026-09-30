using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace libBityLab.entidades
{
    public class COMPRAS_PRODUCTOS
    {
        public int id { get; set; }
        public int id_proveedor { get; set; }
        public int id_sucursal { get; set; }
        public DateTime fecha_orden { get; set; }
        public string? estado_orden { get; set; }
        public decimal total_estimado { get; set; }
        public string? notas_internas { get; set; }
        [ForeignKey("SUCURSALES")] public SUCURSALES? _SUCURSALES { get; set; }
        [ForeignKey("PROVEEDORES")] public PROVEEDORES? _PROVEEDORES { get; set; }
        public List<DETALLES_ORDENES_COMPRAS>? DETALLES_ORDENES_COMPRAS { get; set; }
      

    }
  
}
