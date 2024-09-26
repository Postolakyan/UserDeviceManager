using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserDeviceManager.Business.Interfaces;
using UserDeviceManager.Business.Models;
using UserDeviceManager.Data.Interfaces;
using UserDeviceManager.Data.Models;
using IDeviceAction = UserDeviceManager.Business.Interfaces.IDeviceAction;

namespace UserDeviceManager.Business.Services;

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
        return mapper.Map<DeviceDomainModel>(await unit.DeviceRepository.GetAllAsync(token)
            .Include(device => device.User)
            .FirstOrDefaultAsync(device => device.Id == id));
    }
    public async Task<IEnumerable<DeviceDomainModel>> GetAllAsync(CancellationToken token)
    {
        IEnumerable<Device> models = await unit.DeviceRepository.GetAllAsync(token).Include(d => d.User).ToListAsync(token);
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
    public string PerformeAction(DeviceDomainModel deviceDomainModel)
    {
        IDeviceAction deviceAction = deviceDomainModel.DeviceType switch
        {
            Data.Enum.DeviceType.Printer => new PrinterService(),
            Data.Enum.DeviceType.Phone => new PhoneService(),
            Data.Enum.DeviceType.Laptop => new LaptopService(),
            _ => throw new ArgumentException("Unknown device type.")
        };
        return deviceAction.PerformeAction();
    }
    #endregion CRUD
}
