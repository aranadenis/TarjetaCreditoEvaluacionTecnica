using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Dtos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class TarjetaRepository: ITarjetaRepository
    {
        private readonly CreditCardDbContext _context;

        public TarjetaRepository(CreditCardDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TarjetaConsulta> GetAll()
        {
            var tarjetas = new List<TarjetaConsulta>();

            using (var connection = _context.Database.GetDbConnection())
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "dbo.RecuperarTarjetasActivas";
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tarjetas.Add(new TarjetaConsulta
                            {
                                TarjetaID = reader.GetInt32(reader.GetOrdinal("TarjetaID")),
                                NumeroTarjeta = Convert.ToBase64String(Encoding.UTF8.GetBytes(reader.GetString(reader.GetOrdinal("NumeroTarjeta")))),
                                CVV = Convert.ToBase64String(Encoding.UTF8.GetBytes(reader.GetString(reader.GetOrdinal("CVV")))),
                                NombreTitular = reader.GetString(reader.GetOrdinal("NombreTitular")),
                                FechaEmision = reader.GetDateTime(reader.GetOrdinal("FechaEmision")),
                                FechaExpiracion = reader.GetDateTime(reader.GetOrdinal("FechaExpiracion")),
                                LimiteCredito = reader.GetDecimal(reader.GetOrdinal("LimiteCredito")),
                                SaldoUtilizado = reader.GetDecimal(reader.GetOrdinal("SaldoUtilizado")),
                                SaldoDisponible = reader.GetDecimal(reader.GetOrdinal("SaldoDisponible")),
                                PorcentajeInteres = reader.GetDecimal(reader.GetOrdinal("PorcentajeInteres")),
                                PorcentajeSaldoMinimo = reader.GetDecimal(reader.GetOrdinal("PorcentajeSaldoMinimo")),
                               // EstadoDescripcion = reader.GetString(reader.GetOrdinal("EstadoDescripcion")),
                                NombreUsuario = reader.GetString(reader.GetOrdinal("NombreUsuario"))
                            });
                        }
                    }
                }
            }

            return tarjetas;
        }

        public TarjetaConsulta GetTarjetaById(int id)
        {
            TarjetaConsulta tarjeta = null;

            using (var connection = _context.Database.GetDbConnection())
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "dbo.RecuperarTarjetaCredito";
                    command.CommandType = CommandType.StoredProcedure;

                    // Agregar el parámetro para el procedimiento almacenado
                    var tarjetaIdParam = new SqlParameter("@TarjetaID", id);
                    command.Parameters.Add(tarjetaIdParam);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tarjeta = new TarjetaConsulta
                            {
                                TarjetaID = reader.GetInt32(reader.GetOrdinal("TarjetaID")),
                                NumeroTarjeta = Convert.ToBase64String(Encoding.UTF8.GetBytes(reader.GetString(reader.GetOrdinal("NumeroTarjeta")))),
                                CVV = Convert.ToBase64String(Encoding.UTF8.GetBytes(reader.GetString(reader.GetOrdinal("CVV")))),

                                NombreTitular = reader.GetString(reader.GetOrdinal("NombreTitular")),
                                FechaEmision = reader.GetDateTime(reader.GetOrdinal("FechaEmision")),
                                FechaExpiracion = reader.GetDateTime(reader.GetOrdinal("FechaExpiracion")),
                                LimiteCredito = reader.GetDecimal(reader.GetOrdinal("LimiteCredito")),
                                SaldoUtilizado = reader.GetDecimal(reader.GetOrdinal("SaldoUtilizado")),
                                SaldoDisponible = reader.GetDecimal(reader.GetOrdinal("SaldoDisponible")),
                                PorcentajeInteres = reader.GetDecimal(reader.GetOrdinal("PorcentajeInteres")),
                                PorcentajeSaldoMinimo = reader.GetDecimal(reader.GetOrdinal("PorcentajeSaldoMinimo")),
                                EstadoDescripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                                NombreUsuario = reader.GetString(reader.GetOrdinal("NombreUsuario"))
                            };
                        }
                    }
                }
            }

            return tarjeta;
        }




        public void Add(Tarjeta tarjeta)
        {
            // Usar el procedimiento almacenado
            using (var connection = _context.Database.GetDbConnection())
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "dbo.InsertarTarjetaCredito";
                    command.CommandType = CommandType.StoredProcedure;

                    // Agregar los parámetros
                    command.Parameters.Add(new SqlParameter("@UsuarioID", tarjeta.UsuarioID));
                    command.Parameters.Add(new SqlParameter("@NumeroTarjeta", tarjeta.NumeroTarjeta));
                    command.Parameters.Add(new SqlParameter("@NombreTitular", tarjeta.NombreTitular));
                    command.Parameters.Add(new SqlParameter("@FechaEmision", tarjeta.FechaEmision));
                    command.Parameters.Add(new SqlParameter("@FechaExpiracion", tarjeta.FechaExpiracion));
                    command.Parameters.Add(new SqlParameter("@CVV", tarjeta.CVV));
                    command.Parameters.Add(new SqlParameter("@LimiteCredito", tarjeta.LimiteCredito));
                    command.Parameters.Add(new SqlParameter("@EstadoID", tarjeta.EstadoID));
                    command.Parameters.Add(new SqlParameter("@TipoTarjetaID", tarjeta.TipoTarjetaID));

                    // Ejecutar el procedimiento almacenado
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Tarjeta tarjeta)
        {
            _context.Tarjetas.Update(tarjeta);
            _context.SaveChanges();
        }

    }
}
