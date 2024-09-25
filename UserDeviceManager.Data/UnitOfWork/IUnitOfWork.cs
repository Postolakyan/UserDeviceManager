using UserDeviceManager.Data.IRepository;

namespace UserDeviceManager.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IDeviceRepository DeviceRepository { get; set; }
        IUserRepository UserRepository { get; set; }
        Task Save(CancellationToken token);
    }
}