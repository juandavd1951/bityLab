using System;
using System.Collections.Generic;
using System.Text;

namespace libBityLab.entidades
{
    public class PROVEEDORES
    {

        public int id { get; set; }
        public string? nombreEmpresa { get; set; }
        public string? nitEmpresa { get; set; }
        public string? nombreContacto { get; set; }
        public string? telefonoPrincipal { get; set; }
        public string? correoVentas { get; set; }
        public string? direccionFisica { get; set; }
        public List<COMPRAS_PRODUCTOS>? COMPRAS_PRODUCTOS { get; set; }
    }

  
}
