using AutoMapper;
using Model.Dtos;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<TarjetaDto, Tarjeta>()
                .ForMember(dest => dest.CVV, opt => opt.MapFrom(src => Convert.FromBase64String(src.CVV)))
                .ForMember(dest => dest.NumeroTarjeta, opt => opt.MapFrom(src => Convert.FromBase64String(src.NumeroTarjeta)));
            CreateMap<CompraDto, Compra>().ReverseMap();
            CreateMap<Pago, PagoDto>().ReverseMap();
            CreateMap<EstadoCuenta, EstadoCuentaDto>();
            CreateMap<CompraMesActual, CompraMesActualDto>();



        }

    }
}
