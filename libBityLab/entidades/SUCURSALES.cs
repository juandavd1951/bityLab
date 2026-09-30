using System;
using System.Collections.Generic;
using System.Text;

namespace libBityLab.entidades
{
    public class SUCURSALES
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public string? direccion { get; set; }
        public string? ciudad { get; set; }
        public string? telefono_contacto { get; set; }
        public string? horario_atencion { get; set; }
        public List<COMPRAS_PRODUCTOS>? COMPRAS_PRODUCTOS { get; set; }
        public List<VENTAS>? VENTAS { get; set; }
    }

}
