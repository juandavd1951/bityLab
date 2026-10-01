
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace libBityLab.entidades
{
    public class PRODUCTOS
    {

        public int id { get; set; }
        public int categoria { get; set; }
        public int id_marca { get; set; }
        public string? nombreProducto { get; set; }
        public string? descripcionLarga { get; set; }
        public decimal precioVenta { get; set; } = 0;
        public string? NumeroSerie { get; set; }
        public string? modelo { get; set; }
        public string? especificacionesTecnicas { get; set; }
        [ForeignKey("id_marca")] public MARCAS? _MARCAS { get; set; }
        public List<DETALLE_VENTAS>? DETALLE_VENTAS { get; set; }
        public List<DETALLES_ORDENES_COMPRAS>? DETALLES_ORDENES_COMPRAS { get; set; }
        public List<INVENTARIOS>? INVENTARIOS { get; set; }
        public List<RESENAS>? GARANTIAS { get; set; }


    }
}
