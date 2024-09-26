namespace UserDeviceManager.Data.Configurations;

public class DeviceConfiguration : IEntityTypeConfiguration<Device>
{
    public void Configure(EntityTypeBuilder<Device> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasMaxLength(25).IsRequired();
        builder.Property(x => x.Model).HasMaxLength(25).IsRequired();
        builder.Property(x => x.SerialNumber).HasMaxLength(25).IsRequired();
    }
}
