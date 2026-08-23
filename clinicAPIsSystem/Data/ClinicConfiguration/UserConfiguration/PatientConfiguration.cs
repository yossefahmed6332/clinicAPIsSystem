using clinicAPIsSystem.Models.User; 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace clinicAPIsSystem.Data.ClinicConfiguration.UserConfiguration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            // Set properties
            builder.Property(p => p.MedicalRecordId).IsRequired();
            //set indexes
            builder.HasIndex(p => p.MedicalRecordId).IsUnique();
            //set relationships
            builder.HasOne(p => p.MedicalRecord)
                .WithOne(m => m.Patient)
                .HasForeignKey<Patient>(p => p.MedicalRecordId)
                .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
