using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using clinicAPIsSystem.Models.User.MedicalStaff;

namespace clinicAPIsSystem.Data.ClinicConfiguration.UserConfiguration.MedicalStaffConfiguration
{
    public class NurseConfiguration : IEntityTypeConfiguration<Nurse>
    {
        public void Configure(EntityTypeBuilder<Nurse> builder)
        {
            // Additional configuration for Nurse entity can be added here if needed>
            {
            }
        }
    }
}