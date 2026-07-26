using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders; 
using clinicAPIsSystem.Models;
namespace clinicAPIsSystem.Data.ClinicConfiguration
{
    public class PrescriptionConfiguration:IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Diagnosis)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.DoctorId)
                .IsRequired();
            builder.Property(x => x.PatientId)
                .IsRequired();

            //set relations 
            builder.HasOne(x => x.Patient)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Doctor)
                .WithMany(d => d.Prescriptions)
                .HasForeignKey(x => x.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);



        }
    
    }
}
