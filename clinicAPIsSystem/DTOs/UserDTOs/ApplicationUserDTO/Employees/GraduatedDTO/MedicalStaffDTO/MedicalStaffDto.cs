namespace clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO.Employees.GraduatedDTO.MedicalStaffDTO
{
    public class MedicalStaffDto: GraduatedDto
    {
        public  string Specialization { get; protected set; }
        public MedicalStaffDto(int id, string userName, string email, string firstName, string lastName, string phoneNumber, decimal salaryPerHour, int hoursWorked, TimeOnly shiftStart, TimeOnly shiftEnd, string degree, string university, int yearsOfExperience, int graduationYear, string licenseNumber, string specialization)
            : base(id, userName, email, firstName, lastName, phoneNumber, salaryPerHour, hoursWorked, shiftStart, shiftEnd, degree, university, yearsOfExperience, graduationYear, licenseNumber)
        {
            Specialization = specialization;
        }
    }
    
    
}
