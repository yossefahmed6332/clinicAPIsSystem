using clinicAPIsSystem.Models;
using clinicAPIsSystem.Models.User.MedicalStaff;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
    
namespace clinicAPIsSystem.Data.ClinicConfiguration
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a=>a.DoctorId)
                .IsRequired();
            builder.Property(a => a.PatientId)
                .IsRequired (); 
            builder.Property(a => a.AppointmentDate)
                .IsRequired().HasColumnType("datetime2");
            builder.Property(a => a.Reason)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(a => a.Note)
                .HasMaxLength(200);
            builder.Property(a => a.Status)
                .IsRequired()
                .HasMaxLength(50);

            //set relation 
            builder.HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);
            





        }
    }
}
