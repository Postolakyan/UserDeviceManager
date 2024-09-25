namespace UserDeviceManager.Data.Context;

public class DeviceManagerDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Device> Devices { get; set; }

    public DeviceManagerDbContext()
    {

    }
    public DeviceManagerDbContext(DbContextOptions<DeviceManagerDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new DeviceConfiguration());
    }
}
