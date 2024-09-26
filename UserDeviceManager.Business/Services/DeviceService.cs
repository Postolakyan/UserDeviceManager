using AutoMapper;
using UserDeviceManager.Business.Interfaces;
using UserDeviceManager.Business.Models;
using UserDeviceManager.Data.Interfaces;
using UserDeviceManager.Data.Models;

namespace UserDeviceManager.Business.Services
{
    public class DeviceService(IUnitOfWork unit, IMapper mapper) : IDeviceService
    {
        private readonly IUnitOfWork unit = unit;
        private readonly IMapper mapper = mapper;

        #region CRUD
        public async Task AddAsync(DeviceDomainModel addDevice, CancellationToken token)
        {
            Device deviceModel = mapper.Map<Device>(addDevice);
            unit.DeviceRepository.Add(deviceModel, token);
            await unit.Save(token);
        }
        public async Task<DeviceDomainModel> GetAsync(int id, CancellationToken token)
        {
            return mapper.Map<DeviceDomainModel>(await unit.DeviceRepository.GetByIdAsync(id, token));
        }
        public async Task<IEnumerable<DeviceDomainModel>> GetAllAsync(CancellationToken token)
        {
            IEnumerable<Device> models = await unit.DeviceRepository.GetAllAsync(token);
            IEnumerable<DeviceDomainModel> newmodels = models.Select(e => mapper.Map<DeviceDomainModel>(e));
            return newmodels;
        }
        public async Task UpdateAsync(DeviceDomainModel device, CancellationToken token)
        {
            unit.DeviceRepository.Update(mapper.Map<Device>(device));
            await unit.Save(token);
        }
        public async Task<bool> Delete(int id, CancellationToken token)
        {
            bool isDeleted = await unit.DeviceRepository.DeleteAsync(id, token);
            if (isDeleted)
            {
                await unit.Save(token);
                return true;
            }
            return false;
        }
        #endregion CRUD
    }
}
