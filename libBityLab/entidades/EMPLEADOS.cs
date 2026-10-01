using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace libBityLab.entidades
{
    public class EMPLEADOS
    {
        public int id { get; set; }
        public int id_usuario { get; set; }
        public int id_sucursal { get; set; }
        public string cargopuesto { get; set; } = string.Empty;
        public decimal salario { get; set; }
        public DateTime fechaContratacion { get; set; }
        [ForeignKey("id_usuario")]public USUARIOS? _USUARIO { get; set; }
        [ForeignKey("id_sucursal")]public SUCURSALES? _SUCURSAL { get; set; }
       
    }

}
