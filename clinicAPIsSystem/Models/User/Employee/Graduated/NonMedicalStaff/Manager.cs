
namespace clinicAPIsSystem.Models.User.Employee.Graduated.NonMedicalStaff
{
    public class Manager:NonMedicalStaff
    {
        public Manager(string firstName, string lastName, string userName, string email, decimal salaryPerHour, int hoursWorked, TimeOnly shiftStart, TimeOnly shiftEnd, string degree, string university, int yearsOfExperience, int graduationYear, string license) : base(firstName, lastName, userName, email, salaryPerHour, hoursWorked, shiftStart, shiftEnd, degree, university, yearsOfExperience, graduationYear, license)
        {
        }
        public Manager() { }

    }
}
