using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using clinicAPIsSystem.Models.User.MedicalStaff;
namespace clinicAPIsSystem.Data.ClinicConfiguration.UserConfiguration.MedicalStaffConfiguration
{
    public class MedicalStaffConfiguration: IEntityTypeConfiguration<MedicalStaff>
    {
        public void Configure(EntityTypeBuilder<MedicalStaff> builder)
        {
            builder.Property(ms => ms.YearsOfExperience)
                .IsRequired(); 
            builder.Property(ms => ms.LicenseNumber)
                .IsRequired()
                .HasMaxLength(50); 
            builder.Property(ms => ms.QualificationId)
                .IsRequired(); 

            //set relations 
            builder.HasOne(ms => ms.Qualification)
                .WithMany(q => q.MedicalStaffs)
                .HasForeignKey(ms => ms.QualificationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
