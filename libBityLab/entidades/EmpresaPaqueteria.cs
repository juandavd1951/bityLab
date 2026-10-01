using System;
using System.Collections.Generic;
using System.Text;

namespace libBityLab.entidades
{
    public class EmpresaPaqueteria
    {
        public int id { get; set; }
        public string telefono { get; set; } = string.Empty;
        public string correoElectronico { get; set; } = string.Empty;
        public string NIT { get; set; } = string.Empty;
        public string nombrePaqueteria { get; set; } = string.Empty;
        public List<ENVIOS>? ENVIOS { get; set; }
    }
 
}
