using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models.ViewModel
{
    public class RegistrarEmpresaViewModel
    {
        // Campos para Usuario
        [Display(Name = "Usuario")]
        public string NombreUsuario { get; set; }
        [Display(Name = "Contraseña")]
        public string ContraseniaUsuario { get; set; }


        // Campos para Empresa
        public string Correo { get; set; }

        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string Descripcion { get; set; }

        public decimal Telefono { get; set; }
    }
}
