using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace libBityLab.entidades
{
    public class ENVIOS
    {
        public int id { get; set; }
        public int id_venta { get; set; }
        public int EmpresaPaqueteriaID { get; set; }
        public string numero_guia { get; set; } = string.Empty;
        public string estado { get; set; } = string.Empty;
        public DateTime fecha_estimada_entrega { get; set; }
        public DateTime fecha_entrega_real { get; set; }
        public decimal costo { get; set; }
        [ForeignKey("EmpresaPaqueteria")] public EmpresaPaqueteria? _EmpresaPaqueteria { get; set; }
        [ForeignKey("id_venta")] public VENTAS? _VENTAS { get; set; }
    }
   
}
