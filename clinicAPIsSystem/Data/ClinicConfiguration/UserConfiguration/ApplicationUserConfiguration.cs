using clinicAPIsSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace clinicAPIsSystem.Data.ClinicConfiguration.UserConfiguration
{
    public class ApplicationUserConfiguration:IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(100); 
            builder.Property(u => u.LastName) 
                .IsRequired() 
                .HasMaxLength(100); 



        }
    }
}
