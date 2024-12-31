using AutoMapper;
using Data.Repository;
using Model.Dtos;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.services
{
    public class PagoService: IPagoService
    {
        private readonly IPagoRepository _pagoRepository;
        private readonly IMapper _mapper;

        public PagoService(IPagoRepository pagoRepository, IMapper mapper)
        {
            _pagoRepository = pagoRepository;
            _mapper = mapper;
        }

        public void AddPago(PagoDto pagoDto)
        {
            // Mapear DTO a la entidad
            var pago = _mapper.Map<Pago>(pagoDto);

            _pagoRepository.Add(pago);
        }

        public IEnumerable<PagoDto> GetPagosByDateRange(DateTime startDate, DateTime endDate)
        {
            var pagos = _pagoRepository.GetByDateRange(startDate, endDate);
            return _mapper.Map<IEnumerable<PagoDto>>(pagos);
        }

        public IEnumerable<PagoDto> GetPagosByMonth(int year, int month)
        {
            var pagos = _pagoRepository.GetPagosByMonth(year, month);
            return _mapper.Map<IEnumerable<PagoDto>>(pagos);
        }
    }
}
