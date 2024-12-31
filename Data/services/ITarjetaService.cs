using Model;
using Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.services
{
    public interface ITarjetaService
    {
        IEnumerable<TarjetaConsulta> GetAllTarjetas();
        TarjetaConsulta GetTarjetaById(int id);
        void AddTarjeta(TarjetaDto tarjeta);
        void UpdateTarjeta(Tarjeta tarjeta);
        
    }
}
