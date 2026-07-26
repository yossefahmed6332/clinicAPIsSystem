using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using clinicAPIsSystem.Models;
namespace clinicAPIsSystem.Data.ClinicConfiguration
{
    public class QualificationConfiguration:IEntityTypeConfiguration<Qualification>
    {
        public void Configure(EntityTypeBuilder<Qualification> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Degree)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.University)
                .IsRequired()
                .HasMaxLength(500);

            //set relation 
           
        }   
    
    }
}
