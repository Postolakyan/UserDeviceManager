using UserDeviceManager.Data.Enum;

namespace UserDeviceManager.Data.Models;

public class Device : IEntity
{
    public int Id { get; set; }
    public User User { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string Description { get; set; }
    public string SerialNumber { get; set; }
    public DeviceType DeviceType { get; set; }
}
