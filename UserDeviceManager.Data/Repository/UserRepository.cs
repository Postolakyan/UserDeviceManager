using UserDeviceManager.Data.Context;
using UserDeviceManager.Data.IRepository;
using UserDeviceManager.Data.Models;

namespace UserDeviceManager.Data.Repository;

public class UserRepository(DeviceManagerDbContext context) : Repository<User>(context), IUserRepository
{
}
