using System.ComponentModel.DataAnnotations;

namespace FrontEndTarjetaCredito.Models
{
    public class CompraViewModel
    {
        public int TarjetaID { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El monto es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor que 0.")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "La fecha de compra es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "Fecha no válida.")]
        public DateTime FechaCompra { get; set; } = DateTime.Now;
    }
}
