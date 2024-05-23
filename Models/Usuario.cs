using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idUsuario")]
        public int idUsuario { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        public string Contrasenia { get; set; }

        [Required]
        [Display(Name = "Tipo")]
        public string Tipo { get; set; }
    }
}
