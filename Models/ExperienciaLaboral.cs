using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    public class ExperienciaLaboral
    {
        [Key]
        [Column("idExperienciaLaboral")]
        public int idExperienciaLaboral { get; set; }

        [Required]
        public string Institucion { get; set; }

        [Required]
        public DateTime Periodo { get; set; }

        [Required]
        public string FuncionesRealizadas { get; set; }

        [ForeignKey("Candidato")]
        public int IdCandidato { get; set; }
        
    }
}
