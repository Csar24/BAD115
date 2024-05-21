using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    public class OfertaLaboral
    {
        [Key]
        [Column("idOfertaLaboral")]
        public int idOfertaLaboral { get; set; }

        [Required]
        public string Cargo { get; set; }

        [Required]
        public int Vacante { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public DateTime FechaLimite { get; set; }

        [Required]
        public decimal Salario { get; set; }

        [Required]
        public string Lugar { get; set; }

        [ForeignKey("Usuario")]
        public int IdEmpresa { get; set; }
      
    }
}
