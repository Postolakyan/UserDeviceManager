using UserDeviceManager.Data.Models;

namespace UserDeviceManager.Business.Models;

public class DeviceDomainMOdel
{
    public int Id { get; set; }
    public User User { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string Description { get; set; }
    public string SerialNumber { get; set; }
}
