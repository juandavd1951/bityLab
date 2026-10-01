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
        public int cantidadDisponible { get; set; }
        public int stockMinimo { get; set; }
        public string estanteriaUbicacion { get; set; } = string.Empty;
        public DateTime ultimaActualizacion { get; set; }
        public int capacidadBodega { get; set; }
        [ForeignKey("id_producto")] public PRODUCTOS? _PRODUCTO { get; set; }
        [ForeignKey("id_sucursal")] public SUCURSALES? _SUCURSAL { get; set; }

    }
 
}
