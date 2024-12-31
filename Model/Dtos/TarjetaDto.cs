using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos
{
    public class TarjetaDto
    {
        public int TarjetaID { get; set; }
        public int UsuarioID { get; set; }
        public string NumeroTarjeta { get; set; } // Convertida a string (Base64) para facilitar transporte
        public string NombreTitular { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public string CVV { get; set; } // Convertida a string (Base64) para transporte seguro
        public decimal LimiteCredito { get; set; }
        public decimal SaldoUtilizado { get; set; }
        public decimal SaldoDisponible { get; set; } // Calculado en base a los valores de LimiteCredito y SaldoUtilizado
        public int EstadoID { get; set; }
        public int TipoTarjetaID { get; set; }
        public decimal PorcentajeInteres { get; set; }
        public decimal PorcentajeSaldoMinimo { get; set; }
        public DateTime? FechaUltimaActualizacion { get; set; }

        //public  Usuario Usuario { get; set; }
        //public  EstadoTarjeta EstadoTarjeta { get; set; }
        //public  TipoTarjeta TipoTarjeta { get; set; }
    }
}
