using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    public class Empresa
    {
        [Key]
        [Column("idEmpresa")]
        public int idEmpresa { get; set; }

        public string Correo { get; set; }

        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string Descripcion { get; set; }

        public decimal Telefono { get; set; }

        [ForeignKey("Usuario")]
        public int idUsuario { get; set; }
    }
}
