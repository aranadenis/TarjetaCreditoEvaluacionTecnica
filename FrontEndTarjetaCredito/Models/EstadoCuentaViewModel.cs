using Model.Dtos;

namespace FrontEndTarjetaCredito.Models
{
    public class EstadoCuentaViewModel
    {
        public string NombreTitular { get; set; }
        public string NumeroTarjeta { get; set; }
        public decimal SaldoUtilizado { get; set; }
        public decimal SaldoDisponible { get; set; }
        public decimal LimiteCredito { get; set; }
        public decimal TotalComprasMesActual { get; set; }
        public decimal TotalComprasMesAnterior { get; set; }
        public decimal InteresBonificable { get; set; }
        public decimal CuotaMinima { get; set; }
        public decimal MontoTotalPagar { get; set; }

        // Lista de compras mensuales
        public List<CompraMesActualDto> ComprasMesActual { get; set; }
    }
}
