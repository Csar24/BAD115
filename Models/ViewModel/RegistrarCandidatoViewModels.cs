using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models.ViewModel
{
    public class RegistrarCandidatoViewModel
    {
        // Campos para Usuario
        [Display(Name = "Usuario")]
        public string NombreUsuario { get; set; }
        [Display(Name = "Contraseña")]
        public string ContraseniaUsuario { get; set; }


        // Campos para Candidato
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

        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Display(Name = "DUI")]
        public decimal DUI { get; set; }

        [Display(Name = "NIT")]
        public decimal NIT { get; set; }

        [Display(Name = "Correo")]
        public string Correo { get; set; }

        [Display(Name = "Red Social")]
        public string RedesSociales { get; set; }
    }
}
