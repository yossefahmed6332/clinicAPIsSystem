using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using clinicAPIsSystem.Models;
namespace clinicAPIsSystem.Data.ClinicConfiguration
{
    public class SpecializationConfiguration : IEntityTypeConfiguration<Specialization>
    {
        public void Configure(EntityTypeBuilder<Specialization> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(a=>a.Description)
                .IsRequired()
                .HasMaxLength(300);
        }
    
    }
}
