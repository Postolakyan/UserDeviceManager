using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserDeviceManager.Api.Models;
using UserDeviceManager.Business.Interfaces;
using UserDeviceManager.Business.Models;

namespace UserDeviceManager.Api.Controllers;


[ApiController]
[Route("[controller]/[Action]")]
public class DeviceController(IDeviceService deviceService, IMapper mapper) : ControllerBase
{
    private readonly IMapper mapper = mapper;
    private readonly IDeviceService deviceservice = deviceService;

    #region CRUD
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] DeviceCreateDto addDevice, CancellationToken token)
    {
        if (addDevice is not null)
        {
            DeviceDomainModel deviceDomainModel = mapper.Map<DeviceDomainModel>(addDevice);
            await deviceService.AddAsync(deviceDomainModel, token);
            return Ok();
        }
        return BadRequest();
    }

    [HttpGet]
    public async Task<IActionResult> Get(int id, CancellationToken token)
    {
        DeviceResponseDto device = mapper.Map<DeviceResponseDto>(await deviceservice.GetAsync(id, token));
        if (device is not null)
        {
            return Ok(device);
        }
        return NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken token)
    {
        IEnumerable<DeviceDomainModel> deviceDomainModels = await deviceservice.GetAllAsync(token);

        IEnumerable<DeviceResponseDto> models = deviceDomainModels.Select(e => mapper.Map<DeviceResponseDto>(e));

        if (models.Any())
        {
            return Ok(models);
        }
        return NotFound();
    }

    [HttpPatch]
    public async Task<IActionResult> Update([FromQuery] int id, [FromBody] DeviceUpdateDto updateDevice, CancellationToken token)
    {
        DeviceDomainModel? device = await deviceservice.GetAsync(id, token);

        if (device is not null)
        {
            DeviceDomainModel model = new()
            {
                Id = device.Id,
                Name = updateDevice.Name,
                Description = updateDevice.Description,
                DeviceType = updateDevice.DeviceType,
                Model = updateDevice.Model,
                SerialNumber = updateDevice.SerialNumber,
                UserId = updateDevice.UserId,
            };
            await deviceservice.UpdateAsync(model, token);
            return Ok();
        }
        return BadRequest();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id, CancellationToken token)
    {
        if (await deviceservice.Delete(id, token))
        {
            return Ok();
        }
        return NotFound();
    }
    #endregion CRUD


    [HttpPost]
    public async Task<IActionResult> PerformeAction(int id, CancellationToken token)
    {
        DeviceDomainModel device = await deviceservice.GetAsync(id, token);
        if (device is not null)
        {
            string result = deviceservice.PerformeAction(device);
            return Ok(result);
        }
        return BadRequest();
    }
}
