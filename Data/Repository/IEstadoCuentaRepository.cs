using Model;
using Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IEstadoCuentaRepository
    {
        EstadoCuenta GetEstadoCuenta(int tarjetaId);
    }
}
