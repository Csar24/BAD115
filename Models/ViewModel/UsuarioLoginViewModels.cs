using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models.ViewModel
{
    public class UsuarioLoginViewModels
    {
        [Required]
        [Display(Name = "Usuario")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        public string Contrasenia { get; set; }
    }
}
