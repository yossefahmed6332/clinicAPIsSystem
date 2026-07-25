using clinicAPIsSystem.Models.User.MedicalStaff;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Net;
namespace clinicAPIsSystem.Data.Configuration.MedicalStaffConfiguration.MedicalStaffConfiguration
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.Property(d => d.SpecializationId)
                .IsRequired();
            //set relation 
            builder.HasOne(d => d.Specialization)
                .WithMany()
                .HasForeignKey(d => d.SpecializationId)
                .OnDelete(DeleteBehavior.Restrict); 


        }
    }
}