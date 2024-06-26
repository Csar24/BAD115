﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models.ViewModel
{
    public class RegistrarEmpresaViewModel
<<<<<<< HEAD
    {// Campos para Usuario
        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        [Display(Name = "Usuario")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string ContraseniaUsuario { get; set; }

        // Campos para Empresa
        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El teléfono debe tener 10 dígitos")]
        public decimal Telefono { get; set; }

        // Campo para el archivo del logo
        [Display(Name = "Logo")]
        public IFormFile Logo { get; set; }
=======
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
>>>>>>> 5f2a491fac35e0e85329578513d30165bbd2b242
    }
}
