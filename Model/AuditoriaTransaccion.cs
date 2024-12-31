using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AuditoriaTransaccion
    {
        public int AuditoriaID { get; set; }
        public string TablaAfectada { get; set; }
        public string Operacion { get; set; } // Valores posibles: 'INSERT', 'UPDATE', 'DELETE'
        public DateTime FechaOperacion { get; set; } = DateTime.Now;
        public string Usuario { get; set; }
        public string DescripcionOperacion { get; set; }
    }
}
