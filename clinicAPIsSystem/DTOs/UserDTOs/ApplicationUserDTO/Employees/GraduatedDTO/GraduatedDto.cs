using System.ComponentModel.DataAnnotations;

namespace clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees.GraduatedDTO
{
    public class GraduatedDto:EmployeeDto
    {
        public string Degree { get; protected set; }
        public string University { get; protected set; }
        public string YearsOfExperience { get; protected set; }
        public int GraduationYear { get; protected set; }
        public string LicenseNumber { get; protected set; }

        public GraduatedDto(int id, string userName, string email, string firstName, string lastName, string phoneNumber, decimal salaryPerHour, int hoursWorked, TimeOnly shiftStart, TimeOnly shiftEnd,string degree,string university,string yearsOfExperience,int graduationYear,string licenseNumber)
            : base(id, userName, email, firstName, lastName, phoneNumber, salaryPerHour, hoursWorked, shiftStart, shiftEnd)
        {
            Degree = degree;
            University = university;
            YearsOfExperience = yearsOfExperience;
            GraduationYear = graduationYear;
            LicenseNumber = licenseNumber;
        }
    }
}
