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
        public DateTime fechaOrden { get; set; }
        public string? estadoOrden { get; set; }
        public decimal totalEstimado { get; set; }
        public string? notasInternas { get; set; }
        [ForeignKey("id_sucursal")] public SUCURSALES? _SUCURSALES { get; set; }
        [ForeignKey("id_proveedor")] public PROVEEDORES? _PROVEEDORES { get; set; }
        public List<DETALLES_ORDENES_COMPRAS>? DETALLES_ORDENES_COMPRAS { get; set; }
      

    }
  
}
