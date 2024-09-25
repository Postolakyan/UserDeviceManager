using System.ComponentModel.DataAnnotations;
using UserDeviceManager.Data.IRepository;

namespace UserDeviceManager.Data.Models;

public class User : IEntity
{
    public int Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public ICollection<Device> Devices { get; set; }
    [EmailAddress(ErrorMessage = "Invalid Email Address")] public string Email { get; set; }
}
