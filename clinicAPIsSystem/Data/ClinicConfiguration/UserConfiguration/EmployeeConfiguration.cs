using clinicAPIsSystem.Models.User;
using Microsoft.EntityFrameworkCore; 
using Microsoft.EntityFrameworkCore.Metadata.Builders; 
namespace clinicAPIsSystem.Data.ClinicConfiguration.UserConfiguration
{
    public class EmployeeConfiguration: IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(a => a.SalaryPerHour).
                IsRequired();
            builder.Property(a=>a.HoursWorked)
                .IsRequired();
            builder.Property(a => a.ShiftStart)
                .IsRequired().HasColumnType("Time");
            builder.Property(a => a.ShiftEnd)
                .IsRequired().HasColumnType("Time");

        }
    }
}
