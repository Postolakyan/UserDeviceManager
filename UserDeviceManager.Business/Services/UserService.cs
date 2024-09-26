using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserDeviceManager.Business.Interfaces;
using UserDeviceManager.Business.Models;
using UserDeviceManager.Data.Interfaces;
using UserDeviceManager.Data.Models;

namespace UserDeviceManager.Business.Services;

public class UserService(IUnitOfWork unit, IMapper mapper) : IUserService
{
    private readonly IUnitOfWork unit = unit;
    private readonly IMapper mapper = mapper;

    #region CRUD
    public async Task AddAsync(UserDomainModel addUser, CancellationToken token)
    {
        User userModel = mapper.Map<User>(addUser);
        unit.UserRepository.Add(userModel, token);
        await unit.Save(token);
    }
    public async Task<UserDomainModel> GetAsync(int id, CancellationToken token)
    {
        return mapper.Map<UserDomainModel>(await unit.UserRepository.GetAllAsync(token).Include(user => user.Devices).FirstOrDefaultAsync(user=>user.Id == id,token));
    }
    public async Task<IEnumerable<UserDomainModel>> GetAllAsync(CancellationToken token)
    {
        IEnumerable<User> models = await unit.UserRepository.GetAllAsync(token).Include(u => u.Devices).ToListAsync(token);
        IEnumerable<UserDomainModel> newmodels = models.Select(e => mapper.Map<UserDomainModel>(e));
        return newmodels;
    }
    public async Task UpdateAsync(UserDomainModel user, CancellationToken token)
    {
        unit.UserRepository.Update(mapper.Map<User>(user));
        await unit.Save(token);
    }
    public async Task<bool> Delete(int id, CancellationToken token)
    {
        bool isDeleted = await unit.UserRepository.DeleteAsync(id, token);
        if (isDeleted)
        {
            await unit.Save(token);
            return true;
        }
        return false;
    }
    #endregion CRUD
}
