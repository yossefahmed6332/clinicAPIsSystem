using clinicAPIsSystem.ClinicDTOs.UserDTOs.EmployeeDTOs;

namespace clinicAPIsSystem.ClinicDTOs.UserDTOs.NonMedicalStaffDTOs.CleanerDTOs
{
    public class CleanerDto:EmployeeDto
    {
        public string CleaningArea { get; set; } = null!;
    }
}
