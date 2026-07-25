using Microsoft.EntityFrameworkCore;
using clinicAPIsSystem.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders; 
namespace clinicAPIsSystem.Data.Configuration
{
    public class UserConfiguration:IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.gender).IsRequired();
        }
    
    }
}
