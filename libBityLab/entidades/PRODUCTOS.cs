
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace libBityLab.entidades
{
    public class PRODUCTOS
    {

        public int id { get; set; }
        public int categoria { get; set; }
        public int id_marca { get; set; }
        public string? nombre_producto { get; set; }
        public string? descripcion_larga { get; set; }
        public decimal precio_venta { get; set; } = 0;
        public string? Número_serie { get; set; }
        public string? modelo { get; set; }
        public string? especificaciones_Técnicas { get; set; }
        [ForeignKey("MARCAS")] public MARCAS? _MARCAS { get; set; }
        public List<DETALLE_VENTAS>? DETALLE_VENTAS { get; set; }
        public List<DETALLES_ORDENES_COMPRAS>? DETALLES_ORDENES_COMPRAS { get; set; }
        public List<INVENTARIOS>? INVENTARIOS { get; set; }
        public List<RESENAS>? GARANTIAS { get; set; }


    }
}
