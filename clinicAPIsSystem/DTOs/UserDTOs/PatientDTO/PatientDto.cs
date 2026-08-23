using clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO;
using System.ComponentModel.DataAnnotations;
namespace clinicAPIsSystem.DTOs.UserDTOs.PatientDTO
{
    public class PatientDto: ApplicationUserDto
    {
        [Required,Range(1,int.MaxValue)]
        public int MedicalRecordId { get; private set; }

        public PatientDto(int id, string userName, string email, string firstName, string lastName, string phoneNumber, int medicalRecordId)
            : base(id, userName, email, firstName, lastName, phoneNumber)
        {
            MedicalRecordId = medicalRecordId;
        }
    }
    
    }

