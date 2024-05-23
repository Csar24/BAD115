using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    public class Evento
    {
        [Key]
        [Column("idEvento")]
        public int idEvento { get; set; }
      

        [Required]
        public string Lugar { get; set; }

        [Required]
        public string TipoEvento { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public string Pais { get; set; }

        [Required]
        public string Anfitrion { get; set; }

        [ForeignKey("Candidato")]
        public int IdCandidato { get; set; }
     
    }
}
