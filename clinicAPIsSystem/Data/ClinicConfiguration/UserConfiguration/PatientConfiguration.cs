using clinicAPIsSystem.Models.User; 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace clinicAPIsSystem.Data.ClinicConfiguration.UserConfiguration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            // Additional configuration for Patient entity can be added here if needed
            
            
        }
    }
}
