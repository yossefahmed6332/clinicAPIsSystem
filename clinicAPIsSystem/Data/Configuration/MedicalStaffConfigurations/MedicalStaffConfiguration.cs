using Microsoft.EntityFrameworkCore;
using clinicAPIsSystem.Models.User.MedicalStaff;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace clinicAPIsSystem.Data.Configuration.MedicalStaffConfiguration
{
    public class MedicalStaffConfiguration : IEntityTypeConfiguration<MedicalStaff>
    {
        public void Configure(EntityTypeBuilder<MedicalStaff> builder)
        {
            builder.Property(x => x.YearsOfExperience).IsRequired();

            builder.Property(x => x.LicenseNumber)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.QualificationId)
                   .IsRequired();

            //set relation
            builder.HasOne(x => x.Qualification)
                   .WithMany()
                   .HasForeignKey(x => x.QualificationId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
