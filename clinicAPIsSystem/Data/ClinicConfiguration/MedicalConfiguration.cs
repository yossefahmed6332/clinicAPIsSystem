using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using clinicAPIsSystem.Models; 
namespace clinicAPIsSystem.Data.ClinicConfiguration
{
    public class MedicalConfiguration:IEntityTypeConfiguration<Medical>
    {
        public void Configure(EntityTypeBuilder<Medical> builder)
        {
            builder.HasKey(x => x.Id); 
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(a => a.TakeTime)
                .IsRequired(); 


        }
    
    }
}
