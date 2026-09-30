using System;
using System.Collections.Generic;
using System.Text;

namespace libBityLab.entidades
{
    public class METODOS_PAGO
    {
        public int id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public List<PAGOS>? PAGOS { get; set; }
        public List<DEVOLUCIONES>? DEVOLUCIONES { get; set; }
    }

}
