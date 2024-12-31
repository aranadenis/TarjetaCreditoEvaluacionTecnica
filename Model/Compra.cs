﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Compra
    {
        public int CompraID { get; set; }
        public int TarjetaID { get; set; }
        public DateTime FechaCompra { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }

        // Relaciones
        public Tarjeta Tarjeta { get; set; }
    }
}
