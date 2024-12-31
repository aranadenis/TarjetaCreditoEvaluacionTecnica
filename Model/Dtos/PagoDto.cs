using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos
{
    public class PagoDto
    {
        public int PagoID { get; set; } 
        public int TarjetaID { get; set; } 
        public DateTime FechaPago { get; set; } 
        public decimal Monto { get; set; } 
    }
}
