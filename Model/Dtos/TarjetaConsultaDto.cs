﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos
{
    public class TarjetaConsultaDto
    {
        public int TarjetaID { get; set; }
        public string NumeroTarjeta { get; set; }
        public string CVV { get; set; }
        public string NombreTitular { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public decimal LimiteCredito { get; set; }
        public decimal SaldoUtilizado { get; set; }
        public decimal SaldoDisponible { get; set; }
        public decimal PorcentajeInteres { get; set; }
        public decimal PorcentajeSaldoMinimo { get; set; }
        public string EstadoDescripcion { get; set; } // Nueva propiedad
        public string NombreUsuario { get; set; }
    }
}
