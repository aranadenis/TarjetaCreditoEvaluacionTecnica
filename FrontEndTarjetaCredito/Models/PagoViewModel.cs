using System.ComponentModel.DataAnnotations;

namespace FrontEndTarjetaCredito.Models
{
    public class PagoViewModel
    {
        public int TarjetaID { get; set; }
        [Required(ErrorMessage = "El monto es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor que 0.")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "La fecha de pago es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "Fecha no válida.")]
        public DateTime FechaPago { get; set; } = DateTime.Now;


    }
}
