using AutoMapper;
using UserDeviceManager.Api.Models;
using UserDeviceManager.Business.Models;

namespace UserDeviceManager.Business.MappingProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserCreateDto, UserDomainModel>().ReverseMap();
        CreateMap<UserUpdateDto, UserDomainModel>().ReverseMap().
            ForMember(dest => dest.Email, opt => opt.Ignore());


        CreateMap<UserResponseDto, UserDomainModel>().ReverseMap();
        CreateMap<DeviceResponseDto, DeviceDomainModel>().ReverseMap();

        CreateMap<DeviceCreateDto, DeviceDomainModel>().ReverseMap();
        CreateMap<DeviceUpdateDto, DeviceDomainModel>().ReverseMap();

    }
}
