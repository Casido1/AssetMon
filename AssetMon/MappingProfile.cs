using AssetMon.Models;
using AssetMon.Shared.DTOs;
using AutoMapper;

namespace AssetMon.Main
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Vehicle, VehicleDTO>()
                .ForMember(dest => dest.ContractType, opt => opt.MapFrom(src => src.ContractType.ToString()))
                .ForMember(dest => dest.PaymentFrequency, opt => opt.MapFrom(src => src.PaymentFrequency.ToString()));

            CreateMap<VehicleRepair, VehicleRepairDTO>();

            CreateMap<Payment, PaymentDTO>();
        }
    }
}
