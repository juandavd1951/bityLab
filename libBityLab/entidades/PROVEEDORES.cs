using System;
using System.Collections.Generic;
using System.Text;

namespace libBityLab.entidades
{
    public class PROVEEDORES
    {
        public int id { get; set; }
        public string? nombre_empresa { get; set; }
        public string? nit_empresa { get; set; }
        public string? nombre_contacto { get; set; }
        public string? telefono_principal { get; set; }
        public string? correo_ventas { get; set; }
        public string? direccion_fisica { get; set; }
        public List<COMPRAS_PRODUCTOS>? COMPRAS_PRODUCTOS { get; set; }
    }

  
}
