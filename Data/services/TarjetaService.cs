using AutoMapper;
using Data.Repository;
using Model;
using Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.services
{
    public class TarjetaService:ITarjetaService
    {
        private readonly IMapper _mapper;
        private readonly ITarjetaRepository _tarjetaRepository;

        public TarjetaService(IMapper mapper, ITarjetaRepository tarjetaRepository)
        {
            _tarjetaRepository = tarjetaRepository;
            _mapper = mapper;
        }

        public IEnumerable<TarjetaConsulta> GetAllTarjetas()
        {
            return _tarjetaRepository.GetAll();
        }

        public TarjetaConsulta GetTarjetaById(int id)
        {
            return _tarjetaRepository.GetTarjetaById(id);
        }

        public void AddTarjeta(TarjetaDto tarjetaDto)
        {
            try
            {
                // Mapear DTO a la entidad
                var tarjeta = _mapper.Map<Tarjeta>(tarjetaDto);

            _tarjetaRepository.Add(tarjeta);
            }
            catch (FormatException ex)
            {
                throw new Exception("Error al mapear datos de la tarjeta: " + ex.Message, ex);
            }
        }

        public void UpdateTarjeta(Tarjeta tarjeta)
        {
            _tarjetaRepository.Update(tarjeta);
        }
    }
}
