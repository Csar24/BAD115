using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApplication4.Models
{
    public class Candidato
    {
        [Key]
        [Column("idCandidato")]
        public int idCandidato { get; set; }

        [Display(Name = "Primer Nombre")]
        public string PrimerNombre { get; set; }

        [Display(Name = "Segundo Nombre")]
        public string SegundoNombre { get; set; }

        [Display(Name = "Primer Apellido")]
        public string PrimerApellido { get; set; }
        [Display(Name = "Segundo Apellido")]
        public string SegundoApellido { get; set; }

        [Display(Name = "Nacionalidad")]
        public string Nacionalidad { get; set; }

        [Display(Name = "Genero")]
        public string Genero { get; set; }

        [Display(Name = "Fecha de NAcimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Display(Name = "DUI")]
        public decimal DUI { get; set; }

        [Display(Name = "NIT")]
        public decimal NIT { get; set; }

        [EmailAddress]
        [Display(Name = "Correo")]
        public string Correo { get; set; }
        [Display(Name = "Facebook")]
        public string RedesSociales { get; set; }

        [ForeignKey("Usuario")]
        public int idUsuario { get; set; }

       

    }
}
