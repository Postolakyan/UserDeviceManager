using UserDeviceManager.Data.Context;
using UserDeviceManager.Data.IRepository;
using UserDeviceManager.Data.Models;

namespace UserDeviceManager.Data.Repository;

public class DeviceRepository(DeviceManagerDbContext context) : Repository<Device>(context), IDeviceRepository
{

}
