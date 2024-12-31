using Model;
using Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface ICompraRepository
    {
        void Add(Compra compra);
        IEnumerable<Compra> GetByDateRange(DateTime startDate, DateTime endDate);
        IEnumerable<Compra> GetByMonth(int year, int month);

        IEnumerable<CompraMesActual> GetComprasMesActual(int tarjetaId);


    }
}
