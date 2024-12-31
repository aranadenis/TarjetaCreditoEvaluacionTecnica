using Model;
using Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface ITarjetaRepository
    {
        IEnumerable<TarjetaConsulta> GetAll();
       // Tarjeta GetById(int id);
        TarjetaConsulta GetTarjetaById(int id);
        void Add(Tarjeta tarjeta);
        void Update(Tarjeta tarjeta);
       // void Delete(int id);
    }
}
