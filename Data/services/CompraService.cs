using AutoMapper;
using Data.Repository;
using Model.Dtos;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Data.services
{
    public class CompraService: ICompraService
    {
        private readonly ICompraRepository _compraRepository;
        private readonly IMapper _mapper;


        public CompraService(ICompraRepository compraRepository, IMapper mapper)
        {
            _compraRepository = compraRepository;
            _mapper = mapper;
        }

        public void AddCompra(CompraDto compraDto)
        {
           
            var compra = _mapper.Map<Compra>(compraDto);
            _compraRepository.Add(compra);
            
        }

        public IEnumerable<CompraDto> GetComprasByDateRange(DateTime startDate, DateTime endDate)
        {
            var compras = _compraRepository.GetByDateRange(startDate, endDate);
            return _mapper.Map<IEnumerable<CompraDto>>(compras);
        }

        public IEnumerable<CompraDto> GetComprasByMonth(int year, int month)
        {
            var compras = _compraRepository.GetByMonth(year, month);
            return _mapper.Map<IEnumerable<CompraDto>>(compras);
        }

        public IEnumerable<CompraMesActualDto> ObtenerComprasMesActual(int tarjetaId)
        {
            if (tarjetaId <= 0)
                throw new ArgumentException("El ID de la tarjeta no es válido.");

            var comprasMesActual = _compraRepository.GetComprasMesActual(tarjetaId);

            if (comprasMesActual == null || !comprasMesActual.Any())
                throw new InvalidOperationException("Las compras no pudieron ser recuperadas.");

            // Mapear cada entidad de CompraMesActual a CompraMesActualDto
            return _mapper.Map<IEnumerable<CompraMesActualDto>>(comprasMesActual);
        }

    }
}
