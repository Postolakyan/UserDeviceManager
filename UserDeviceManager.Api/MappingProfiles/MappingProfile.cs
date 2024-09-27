namespace UserDeviceManager.Business.MappingProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserCreateDto, UserDomainModel>().ReverseMap();
        CreateMap<UserUpdateDto, UserDomainModel>().ReverseMap();
         //   ForMember(dest => dest.Email, opt => opt.Ignore());


        CreateMap<UserResponseDto, UserDomainModel>()
           .ForMember(dest => dest.Devices, opt =>
               opt.MapFrom(src => src.DeviceNames.Select(name => new Device { Name = name })))
           .ReverseMap()
           .ForMember(dest => dest.DeviceNames, opt =>
               opt.MapFrom(src => src.Devices.Select(device => device.Name)));

        CreateMap<DeviceResponseDto, DeviceDomainModel>()
            .ReverseMap()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(u => u.User.FirstName));

        CreateMap<DeviceCreateDto, DeviceDomainModel>().ReverseMap();
        CreateMap<DeviceUpdateDto, DeviceDomainModel>().ReverseMap();

    }
}
