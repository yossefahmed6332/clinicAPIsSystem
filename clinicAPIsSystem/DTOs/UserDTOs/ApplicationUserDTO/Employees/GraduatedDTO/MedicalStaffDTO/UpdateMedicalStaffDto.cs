namespace clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees.GraduatedDTO.MedicalStaffDTO
{
    public class UpdateMedicalStaffDto:UpdateGraduatedDto
    {
        public string Specialization { get; private set; }
        public UpdateMedicalStaffDto(string userName, string email, string firstName, string lastName, string phoneNumber, decimal salaryPerHour, int hoursWorked, TimeOnly shiftStart, TimeOnly shiftEnd, string degree, string university, string yearsOfExperience, int graduationYear, string licenseNumber, string specialization)
: base(userName, email, firstName, lastName, phoneNumber, salaryPerHour, hoursWorked, shiftStart, shiftEnd, degree, university, yearsOfExperience, graduationYear, licenseNumber)
        {
            Specialization = specialization;
        }
    }
}
