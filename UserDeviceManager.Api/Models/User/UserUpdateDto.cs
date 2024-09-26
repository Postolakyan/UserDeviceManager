namespace UserDeviceManager.Api.Models;

public class UserUpdateDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateTime DateOfBirth { get; set; }
}
