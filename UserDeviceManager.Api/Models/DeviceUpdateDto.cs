using UserDeviceManager.Data.Enum;
using UserDeviceManager.Data.Models;

namespace UserDeviceManager.Api.Models
{
    public class DeviceUpdateDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string SerialNumber { get; set; }
        public DeviceType DeviceType { get; set; }
    }
}
