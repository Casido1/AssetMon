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

            CreateMap<VehicleRepairToCreateDTO, VehicleRepairDTO>();

            CreateMap<VehicleRepairToUpdateDTO, VehicleRepairDTO>();

            CreateMap<Payment, PaymentDTO>();

            CreateMap<VehicleToCreateDTO, Vehicle>()
                .ForMember(dest => dest.ContractType, opt => opt.MapFrom(src => (Contracts)src.ContractType))
                .ForMember(dest => dest.PaymentFrequency, opt => opt.MapFrom(src => (PaymentFrequency)src.PaymentFrequency));

            CreateMap<PaymentToCreateDTO, Payment>();

            CreateMap<PaymentToUpdateDTO, Payment>();

            CreateMap<VehicleToUpdateDTO, Vehicle>()
                .ForMember(dest => dest.ContractType, opt => opt.MapFrom(src => (Contracts)src.ContractType))
                .ForMember(dest => dest.PaymentFrequency, opt => opt.MapFrom(src => (PaymentFrequency)src.PaymentFrequency));

            CreateMap<UserForRegisterationDTO, AppUser>();

            CreateMap<UserForRegisterationDTO, UserProfile>();

            CreateMap<UserProfile, UserProfileDTO>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));

            CreateMap<UserProfileToUpdateDTO, UserProfile>();

            CreateMap<Address, AddressDTO>();

            CreateMap<AddressToCreateDTO, Address>();

            CreateMap<AddressToUpdateDTO, Address>();
        }
    }
}
