using clinicAPIsSystem.ClinicDTOs.UserDTOs.EmployeeDTOs;
using clinicAPIsSystem.ClinicDTOs.OperationDtos; 
namespace clinicAPIsSystem.ClinicDTOs.UserDTOs.NonMedicalStaffDTOs.AccountantDTOs
{
    public class AccountantDto:EmployeeDto
    {
        public string LicenseNumber { get; set; } = null!;
        public int YearsOfExperience { get; set; }

        public ICollection<OperationDto> Operations { get; set; } = new List<OperationDto>();

    }
}
