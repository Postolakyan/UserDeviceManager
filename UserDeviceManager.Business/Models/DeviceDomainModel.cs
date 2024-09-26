using UserDeviceManager.Data.Enum;

namespace UserDeviceManager.Business.Models;

public class DeviceDomainModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string Description { get; set; }
    public string SerialNumber { get; set; }
    public DeviceType DeviceType { get; set; }
}
