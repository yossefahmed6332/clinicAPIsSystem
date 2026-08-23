using System.ComponentModel.DataAnnotations;

namespace clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees.GraduatedDTO
{
    public class CreateGraduatedDto:CreateEmployeeDto
    {
        [Required,MaxLength(100)]
        public string Degree { get; protected set; }
        [Required,MaxLength(100)]
        public string University { get; protected set; }
        [Required,MaxLength(100)]
        public string YearsOfExperience { get; protected set; }
        [Required,Range(1900,2600)]
        public int GraduationYear { get; protected set; }
        [Required, MaxLength(100)]
        public string LicenseNumber { get; protected set; }

        public CreateGraduatedDto(string firstName,string lastName,string email,string userName,string phoneNumber,decimal salaryPerHour,int hoursWorked,TimeOnly shiftStart,TimeOnly shiftEnd,string degree,string university,string yeatsOfExperience,int graduationYear,string licenseNumber)
            : base(firstName, lastName, email, userName, phoneNumber, salaryPerHour, hoursWorked, shiftStart, shiftEnd)
        {
            Degree = degree;
            University = university;
            YearsOfExperience = yeatsOfExperience;
            GraduationYear = graduationYear;
            LicenseNumber = licenseNumber;
        }

    }
}
