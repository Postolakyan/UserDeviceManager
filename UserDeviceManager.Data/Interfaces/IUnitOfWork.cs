namespace UserDeviceManager.Data.Interfaces;
public interface IUnitOfWork
{
    Task Save(CancellationToken token);
    IUserRepository UserRepository { get; set; }
    IDeviceRepository DeviceRepository { get; set; }
}