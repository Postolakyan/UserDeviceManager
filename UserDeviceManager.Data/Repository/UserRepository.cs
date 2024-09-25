namespace UserDeviceManager.Data.Repository;

public class UserRepository(DeviceManagerDbContext context) : Repository<User>(context), IUserRepository
{
}
