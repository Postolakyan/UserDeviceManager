using UserDeviceManager.Business.Models;

namespace UserDeviceManager.Business.Interfaces;

public interface IDeviceService
{
    Task AddAsync(DeviceDomainModel addDevice, CancellationToken token);
    Task<bool> Delete(int id, CancellationToken token);
    Task<IEnumerable<DeviceDomainModel>> GetAllAsync(CancellationToken token);
    Task<DeviceDomainModel> GetAsync(int id, CancellationToken token);
    Task UpdateAsync(DeviceDomainModel device, CancellationToken token);
}