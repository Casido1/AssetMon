using AssetMon.Models;
using AssetMon.Models.Enums;
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

            CreateMap<VehicleToCreateDTO, Vehicle>()
                .ForMember(dest => dest.ContractType, opt => opt.MapFrom(src => (Contracts)src.ContractType))
                .ForMember(dest => dest.PaymentFrequency, opt => opt.MapFrom(src => (PaymentFrequency)src.PaymentFrequency));
        }
    }
}
