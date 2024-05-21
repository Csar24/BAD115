using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    public class Pruebas
    {
        [Key]
        [Column("idPruebas")]
        public int idPruebas { get; set; }

        [Required]
        [Column("resultado")]
        public int Resultado { get; set; }

        [ForeignKey("Candidato")]
        public int IdCandidato { get; set; }
        
    }
}
