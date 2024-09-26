using UserDeviceManager.Business.Models;

namespace UserDeviceManager.Business.Interfaces;

public interface IUserService
{
    Task AddAsync(UserDomainModel addUser, CancellationToken token);
    Task<UserDomainModel> GetAsync(int id, CancellationToken token);
    Task<IEnumerable<UserDomainModel>> GetAllAsync(CancellationToken token);
    Task UpdateAsync(UserDomainModel user, CancellationToken token);
    Task<bool> Delete(int id, CancellationToken token);
}