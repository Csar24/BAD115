using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Logo
    {
        
            [Key]
            public int idLogo { get; set; }

            [Required]
            [StringLength(255)]
            public string LogoURL { get; set; }

            [ForeignKey("Empresa")]
            public int idEmpresa { get; set; }
        
    }
}
