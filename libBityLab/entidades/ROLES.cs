
using System.ComponentModel.DataAnnotations.Schema;


namespace libBityLab.entidades
{
    public class ROLES
    {
        public int Id { get; set; }
        public string? nombre { get; set; }
        public string? descripcion { get; set; }
        public decimal salarioEstimado { get; set; } 
       public List<USUARIOS>? USUARIOS { get; set; }

    }

}
