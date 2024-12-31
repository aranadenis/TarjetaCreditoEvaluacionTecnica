using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Movimiento
    {
        public int MovimientoID { get; set; }
        public int TarjetaID { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string TipoMovimiento { get; set; } // Valores posibles: 'COMPRA', 'PAGO'
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }

        // Relaciones
        public Tarjeta Tarjeta { get; set; }
    }
}
