using Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.services
{
    public interface ICompraService
    {
        void AddCompra(CompraDto compraDto);
        IEnumerable<CompraDto> GetComprasByDateRange(DateTime startDate, DateTime endDate);
        IEnumerable<CompraDto> GetComprasByMonth(int year, int month);

        IEnumerable<CompraMesActualDto> ObtenerComprasMesActual(int tarjetaId);
    }
}
