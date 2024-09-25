namespace UserDeviceManager.Data.Repository;

public class DeviceRepository(DeviceManagerDbContext context) : Repository<Device>(context), IDeviceRepository
{

}
