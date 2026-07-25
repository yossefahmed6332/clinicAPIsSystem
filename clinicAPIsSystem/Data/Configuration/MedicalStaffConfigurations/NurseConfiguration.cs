using clinicAPIsSystem.Models.User.MedicalStaff;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace clinicAPIsSystem.Data.Configuration.MedicalStaffConfiguration
{
    public class NurseConfiguration: IEntityTypeConfiguration<Nurse>
    {
        public void Configure(EntityTypeBuilder<Nurse> builder)
        {

        }
    }
}
