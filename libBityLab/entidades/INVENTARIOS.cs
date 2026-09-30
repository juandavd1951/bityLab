using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace libBityLab.entidades
{
    public class INVENTARIOS
    {
        public int id { get; set; }
        public int id_producto { get; set; }
        public int id_sucursal { get; set; }
        public int cantidad_disponible { get; set; }
        public int stock_minimo { get; set; }
        public string estanteria_ubicacion { get; set; } = string.Empty;
        public DateTime ultima_actualizacion { get; set; }
        public int capacidad_bodega { get; set; }
        [ForeignKey("id_producto")] public PRODUCTOS? _PRODUCTO { get; set; }
        [ForeignKey("id_sucursal")] public SUCURSALES? _SUCURSAL { get; set; }

    }
 
}
