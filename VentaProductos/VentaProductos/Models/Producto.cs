using System.ComponentModel.DataAnnotations;

namespace VentaProductos.Models
{
    public class Producto
    {

        public int? CodigoProducto { get; set; }

        [Required(ErrorMessage = "Por favor ingrese una descripcion.")]
        [StringLength(300, ErrorMessage = "La descripcion es demasiado larga.")]
        public string? Descripcion { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 1")]
        [Required(ErrorMessage = "Por favor ingrese el precio del producto")]
        public double? Precio { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "El saldo del inventario debe ser mayor a 1")]
        [Required(ErrorMessage = "Por favor ingrese el saldo del inventario")]
        public double? SaldoInventario { get; set; }

        public DateTime? FechaIngreso { get; set; }

        [Required(ErrorMessage = "Por favor ingrese un nombre de usuario")]
        [StringLength(50, ErrorMessage = "El nombre de usuario es demasiado largo.")]
        public string? UsuarioIngreso { get; set; }

        [Required(ErrorMessage = "Por favor ingrese un ID de Familia")]
        public int? IDFamilia { get; set; }
    }
}
