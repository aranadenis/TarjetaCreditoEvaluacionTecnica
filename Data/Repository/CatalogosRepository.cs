using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class CatalogosRepository: ICatalogosRepository
    {
        private readonly CreditCardDbContext _context;

        public CatalogosRepository(CreditCardDbContext context)
        {
            _context = context;
        }

        public IEnumerable<EstadoTarjeta> GetEstadosTarjeta()
        {
            return _context.EstadosTarjeta.ToList();
        }

        public IEnumerable<TipoTarjeta> GetTiposTarjeta()
        {
            return _context.TiposTarjeta.ToList();
        }

        public void AddEstadoTarjeta(EstadoTarjeta estadoTarjeta)
        {
            _context.EstadosTarjeta.Add(estadoTarjeta);
            _context.SaveChanges();
        }
        public void AddTipoTarjeta(TipoTarjeta tipoTarjeta)
        {
            _context.TiposTarjeta.Add(tipoTarjeta);
            _context.SaveChanges();
        }
    }
}
