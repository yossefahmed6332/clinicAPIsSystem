using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using clinicAPIsSystem.Models.User.NonMedicalStaff;
namespace clinicAPIsSystem.Data.ClinicConfiguration.UserConfiguration.NonMedicalStaffConfi
{
    public class AccountantConfiguration:IEntityTypeConfiguration<Accountant>
    {
        public void Configure(EntityTypeBuilder<Accountant> builder)
        {
            builder.Property(a => a.LicenseNumber)
                .IsRequired()
                .HasMaxLength(100);


        }
    }
}
