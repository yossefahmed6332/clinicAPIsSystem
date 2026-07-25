using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders; 
using clinicAPIsSystem.Models.User.MedicalStaff;
namespace clinicAPIsSystem.Data.MedicalStaffConfiguration
{
    public class DoctorConfiguration:IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.Property(d => d.SpecializationId)
                .IsRequired()
                .HasMaxLength(100);

            //set relations 
            builder.HasOne(d => d.Specialization)
                .WithMany(s => s.Doctors)
                .HasForeignKey(d => d.SpecializationId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
