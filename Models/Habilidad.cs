using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    public class Habilidad
    {
        [Key]
        [Column("idHabilidad")]
        public int idHabilidad { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public string Tipo { get; set; }

        [ForeignKey("Candidato")]
        public int IdCandidato { get; set; }
       
    }
}
