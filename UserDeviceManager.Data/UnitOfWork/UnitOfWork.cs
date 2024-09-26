using UserDeviceManager.Data.Interfaces;
using UserDeviceManager.Data.Repository;

namespace UserDeviceManager.Data.UnitOfWork;

public class UnitOfWork(DeviceManagerDbContext context) : IUnitOfWork
{
    private readonly DeviceManagerDbContext context = context;

    private IUserRepository userRepository;

    public IUserRepository UserRepository
    {
        get
        {
            if (userRepository is null)
            {
                userRepository = new UserRepository(context);
            }

            return userRepository;
        }
        set => userRepository = value;
    }


    private IDeviceRepository deviceRepository;
    public IDeviceRepository DeviceRepository
    {
        get
        {
            if (deviceRepository is null)
            {
                deviceRepository = new DeviceRepository(context);
            }

            return deviceRepository;
        }
        set => deviceRepository = value;
    }

    public async Task Save(CancellationToken token)
    {
        await context.SaveChangesAsync(token);
    }
}
