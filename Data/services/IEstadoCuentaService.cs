using Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.services
{
    public interface IEstadoCuentaService
    {
        EstadoCuentaDto ObtenerEstadoCuenta(int tarjetaId);
    }
}
