using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders; 
using clinicAPIsSystem.Models;
using Microsoft.Data.SqlClient;

namespace clinicAPIsSystem.Data.ClinicConfiguration
{
    public class OperationConfiguration:IEntityTypeConfiguration<Operation>
    {
        public void Configure(EntityTypeBuilder<Operation> builder)
        {
            builder.HasKey(x => x.Id); 
            builder.Property(a=>a.AccountantId)
                .IsRequired();
            builder.Property(a=>a.PatientId)
                .IsRequired();
            builder.Property(a=>a.AppointmentId)
                .IsRequired();
            builder.Property(a => a.Amount)
                .IsRequired();
            builder.Property(a => a.OperationDate)
                .IsRequired().HasColumnType("datetime2");

            //set relations 
            builder.HasOne(a => a.Accountant)
                .WithMany(a => a.Appointments)
                .HasForeignKey(a => a.AccountantId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.Patient)
                .WithMany(a=> a.Operations)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.Appointment)
                .WithMany(a => a.Operations)
                .HasForeignKey(a => a.AppointmentId)
                .OnDelete(DeleteBehavior.Restrict);



        }
    
    }
}
