using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface ICatalogosRepository
    {
        IEnumerable<EstadoTarjeta> GetEstadosTarjeta();
        IEnumerable<TipoTarjeta> GetTiposTarjeta();
        void AddEstadoTarjeta(EstadoTarjeta estadoTarjeta);
        void AddTipoTarjeta(TipoTarjeta tipoTarjeta);
    }
}
