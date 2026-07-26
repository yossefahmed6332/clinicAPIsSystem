using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using clinicAPIsSystem.Models.User.NonMedicalStaff;

namespace clinicAPIsSystem.Data.ClinicConfiguration.UserConfiguration.NonMedicalStaffConfi
{
    public class CleanerConfiguration:IEntityTypeConfiguration<Cleaner>

    {
        public void Configure(EntityTypeBuilder<Cleaner> builder)
        {
            builder.Property(c => c.CleaningArea)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
