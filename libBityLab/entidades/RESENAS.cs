using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace libBityLab.entidades
{
    public class RESENAS
    {
        public int id { get; set; }
        public int id_producto { get; set; }
        public int id_cliente { get; set; }
        public int calificacionEstrellas { get; set; }
        public string? comentario { get; set; }
        public DateTime fechaPublicacion { get; set; }
        [ForeignKey("id_producto")] public PRODUCTOS? _PRODUCTOS { get; set; }
        [ForeignKey("id_cliente")] public CLIENTES? _CLIENTES { get; set; }
    }
}
