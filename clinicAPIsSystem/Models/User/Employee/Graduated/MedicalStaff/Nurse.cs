using Microsoft.OpenApi.Models;

namespace clinicAPIsSystem.Models.User.Employee.Graduated.MedicalStaff
{
    public class Nurse:MedicalStaff
    {
        public ICollection<VitalSigns> VitalSigns { get; set; } = new HashSet<VitalSigns>();
        public ICollection<ExaminationResult> ExaminationResults { get; set; } = new HashSet<ExaminationResult>();

    }
}
