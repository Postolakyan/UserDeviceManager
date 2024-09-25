using System.ComponentModel.DataAnnotations;
using UserDeviceManager.Data.Models;

namespace UserDeviceManager.Business.Models;

public class UserDomainModel
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public ICollection<Device> Devices { get; set; }
}
