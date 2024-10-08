﻿namespace UserDeviceManager.Api.Models;

public class UserResponseDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public ICollection<string> DeviceNames { get; set; }
}
