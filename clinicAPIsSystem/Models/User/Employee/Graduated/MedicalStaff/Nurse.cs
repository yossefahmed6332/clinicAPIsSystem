using Microsoft.OpenApi.Models;

namespace clinicAPIsSystem.Models.User.Employee.Graduated.MedicalStaff
{
    public class Nurse:MedicalStaff
    {
        public Nurse(string firstName, string lastName, string userName, string email, decimal salaryPerHour, int hoursWorked, TimeOnly shiftStart, TimeOnly shiftEnd, string degree, string university, int yearsOfExperience, int graduationYear, string license) : base(firstName, lastName, userName, email, salaryPerHour, hoursWorked, shiftStart, shiftEnd, degree, university, yearsOfExperience, graduationYear, license)
        {
        }
        public Nurse() { }

        public ICollection<VitalSigns> VitalSigns { get;private set; } = new HashSet<VitalSigns>();
        public ICollection<ExaminationResult> ExaminationResults { get; private set; } = new HashSet<ExaminationResult>();

    }
}
