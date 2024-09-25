using Microsoft.EntityFrameworkCore;
using UserDeviceManager.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UserDeviceManager.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u=>u.Id);
        builder.HasIndex(u => u.Email).IsUnique();
        builder.Property(u => u.Email).HasMaxLength(128).IsRequired();
        builder.Property(u => u.LastName).HasMaxLength(128).IsRequired();
        builder.Property(u => u.FirstName).HasMaxLength(128).IsRequired();
    }
}
