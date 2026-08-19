using clinicAPIsSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders; 
namespace clinicAPIsSystem.Data.ClinicConfiguration
{
    public class MedicalRecordConfiguration:IEntityTypeConfiguration<MedicalRecord>
    {
        public void Configure(EntityTypeBuilder<MedicalRecord> builder)
        {
            //set properties
            builder.HasKey(m => m.Id);
            builder.Property(m=>m.Height).IsRequired();
            builder.Property(m => m.Weight).IsRequired();
            builder.Property(m=>m.BloodType).IsRequired();
            builder.Property(m=>m.PatientId).IsRequired();

            //set relationships
            builder.HasOne(m => m.Patient)
                .WithOne(p => p.MedicalRecord)
                .HasForeignKey<MedicalRecord>(m => m.PatientId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
