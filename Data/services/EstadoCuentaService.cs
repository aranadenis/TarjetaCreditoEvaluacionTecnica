using AutoMapper;
using Data.Repository;
using Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.services
{
    public class EstadoCuentaService:  IEstadoCuentaService
    {
        private readonly IEstadoCuentaRepository _estadoCuentaRepository;
        private readonly IMapper _mapper;

        public EstadoCuentaService(IEstadoCuentaRepository estadoCuentaRepository, IMapper mapper)
        {
            _estadoCuentaRepository = estadoCuentaRepository;
            _mapper = mapper;
        }

        public EstadoCuentaDto ObtenerEstadoCuenta(int tarjetaId)
        {

            if (tarjetaId <= 0)
                throw new ArgumentException("El ID de la tarjeta no es válido.");

            var estadoCuenta = _estadoCuentaRepository.GetEstadoCuenta(tarjetaId);

            if (estadoCuenta == null)
                throw new InvalidOperationException("El estado de cuenta no pudo ser recuperado.");

            // Mapear la entidad al DTO usando AutoMapper
            return _mapper.Map<EstadoCuentaDto>(estadoCuenta);
        }
    }
}
