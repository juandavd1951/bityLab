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
        public int id_empresa_paqueteria { get; set; }
        public string numeroGuia { get; set; } = string.Empty;
        public string estado { get; set; } = string.Empty;
        public DateTime fechaEstimadaEntrega { get; set; }
        public DateTime fechaEntregaReal { get; set; }
        public decimal costo { get; set; }
        [ForeignKey("id_empresa_paqueteria")] public EmpresaPaqueteria? _EmpresaPaqueteria { get; set; }
        [ForeignKey("id_venta")] public VENTAS? _VENTAS { get; set; }
    }
   
}
