using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos
{
    public class EstadoCuentaDto
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
    }
}
