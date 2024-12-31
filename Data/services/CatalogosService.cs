using Data.Repository;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.services
{
    public class CatalogosService: ICatalogosService
    {
        private readonly ICatalogosRepository _catalogosRepository;

        public CatalogosService(ICatalogosRepository catalogosRepository)
        {
            _catalogosRepository = catalogosRepository;
        }

        public IEnumerable<EstadoTarjeta> GetEstadosTarjeta()
        {
            return _catalogosRepository.GetEstadosTarjeta();
        }

        public IEnumerable<TipoTarjeta> GetTiposTarjeta()
        {
            return _catalogosRepository.GetTiposTarjeta();
        }

        public void AddEstadoTarjeta(EstadoTarjeta estadoTarjeta)
        {
            _catalogosRepository.AddEstadoTarjeta(estadoTarjeta);
        }

        public void AddTipoTarjeta(TipoTarjeta tipoTarjeta)
        {
            _catalogosRepository.AddTipoTarjeta(tipoTarjeta);
        }
    }
}
