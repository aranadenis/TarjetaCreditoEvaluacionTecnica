using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CreditCardDbContext: DbContext
    {
        public CreditCardDbContext(DbContextOptions<CreditCardDbContext> options) : base(options) {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<EstadoTarjeta> EstadosTarjeta { get; set; }
        public DbSet<TipoTarjeta> TiposTarjeta { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<EstadoCuenta> EstadoCuenta { get; set; }
        public DbSet<CompraMesActual> ComprasMesActual { get; set; }
        public DbSet<AuditoriaTransaccion> AuditoriaTransacciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de Tarjeta
            modelBuilder.Entity<Tarjeta>()
                .Property(t => t.NumeroTarjeta)
                .IsRequired();

            modelBuilder.Entity<Tarjeta>()
                .Property(t => t.LimiteCredito)
                .HasPrecision(10, 2)
                .IsRequired();

            modelBuilder.Entity<AuditoriaTransaccion>()
                .HasKey(a => a.AuditoriaID); // Configura AuditoriaID como clave primaria

            modelBuilder.Entity<EstadoCuenta>()
                .HasKey(a => a.IdEstadoCuenta); // Configura AuditoriaID como clave primaria
            modelBuilder.Entity<CompraMesActual>()
                .HasKey(a => a.CompraID); // Configura AuditoriaID como clave primaria

        }

        }


    }
