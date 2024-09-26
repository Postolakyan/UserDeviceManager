namespace UserDeviceManager.Business.MappingProfiles;

public class MappingProfileDomain : Profile
{
    public MappingProfileDomain()
    {
        CreateMap<UserDomainModel, User>().ReverseMap();
        CreateMap<DeviceDomainModel, Device>().ReverseMap();
    }
}
