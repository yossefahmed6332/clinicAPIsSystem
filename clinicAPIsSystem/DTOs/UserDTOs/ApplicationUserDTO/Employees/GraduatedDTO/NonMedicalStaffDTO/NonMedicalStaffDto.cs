namespace clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees.GraduatedDTO.NonMedicalStaffDTO
{
    public abstract class NonMedicalStaffDto:GraduatedDto
    {
        public NonMedicalStaffDto(int id, string userName, string email, string firstName, string lastName, string phoneNumber, decimal salaryPerHour, int hoursWorked, TimeOnly shiftStart, TimeOnly shiftEnd, string degree, string university, string yearsOfExperience, int graduationYear, string licenseNumber)
            : base(id, userName, email, firstName, lastName, phoneNumber, salaryPerHour, hoursWorked, shiftStart, shiftEnd, degree, university, yearsOfExperience, graduationYear, licenseNumber)
        {

        }
    }
}
