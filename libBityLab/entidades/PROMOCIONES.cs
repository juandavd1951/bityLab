using System;
using System.Collections.Generic;
using System.Text;

namespace libBityLab.entidades
{
    public class PROMOCIONES
    {
        public int id { get; set; }
        public string codigo_cupon { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public decimal porcentaje_descuento { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public List<VENTAS>? VENTAS { get; set; }
    }
    /*CREATE TABLE PROMOCIONES (
    id INT PRIMARY KEY,
    codigo_cupon nvarchar(50),
    descripcion nvarchar(255),
    porcentaje_descuento DECIMAL(5, 2),
    fecha_inicio DATETIME,
    fecha_fin DATETIME*/
}
