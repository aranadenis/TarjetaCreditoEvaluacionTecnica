using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Tarjeta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TarjetaID { get; set; }

        public int UsuarioID { get; set; }

        public string NumeroTarjeta { get; set; }
                
        public string NombreTitular { get; set; }
               
        public DateTime FechaEmision { get; set; }
                
        public DateTime FechaExpiracion { get; set; }
               
        public string CVV { get; set; }
        public decimal LimiteCredito { get; set; }

        public decimal SaldoUtilizado { get; set; }

        [NotMapped]
        public decimal SaldoDisponible => LimiteCredito - SaldoUtilizado;
                        
        public int EstadoID { get; set; }
                
        public int TipoTarjetaID { get; set; }
                
        public decimal PorcentajeInteres { get; set; }

        public decimal PorcentajeSaldoMinimo { get; set; }

        public DateTime? FechaUltimaActualizacion { get; set; }

       
                    
        
    }
}
