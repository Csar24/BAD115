using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    public class Titulo
    {
        [Key]
        [Column("idTitulo")]
        public int idTitulo { get; set; }

        [Required]
        public string NombreTitulo { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public string Institucion { get; set; }

        [ForeignKey("Candidato")]
        public int IdCandidato { get; set; }
       
    }
}
