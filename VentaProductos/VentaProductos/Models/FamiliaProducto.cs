using System.ComponentModel.DataAnnotations;

namespace VentaProductos.Models
{
    public class FamiliaProducto
    {
        public int? IDFamilia { get; set; }

        [Required(ErrorMessage = "Por favor ingrese un nombre de usuario.")]
        [StringLength(50, ErrorMessage = "El nombre de usuario es demasiado largo.")]
        public string? UsuarioIngreso { get; set; }

        [Required(ErrorMessage = "Por favor ingrese un nombre de familia.")]
        [StringLength(50, ErrorMessage = "El nombre de familia es demasiado largo.")]
        public string? NombreFamilia { get; set; }

        [Required(ErrorMessage = "Por favor ingrese un estado.")]
        public int? Estado { get; set; }
    }
}
