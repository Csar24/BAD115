using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class CandidatoOferta
    {
        [Key]
        [Column("idCandidatoOferta")]
        public int idCandidatoOferta { get; set; }
        public int IdCandidato { get; set; }
        public Candidato Candidato { get; set; }

        public int IdOferta { get; set; }
        public OfertaLaboral OfertaLaboral { get; set; }

        public DateTime FechaAplicacion { get; set; }
        public string Estado { get; set; }
    }
}
