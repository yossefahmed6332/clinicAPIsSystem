using clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO;
using clinicAPIsSystem.DTOs.AppointmentDTOs; 
using clinicAPIsSystem.DTOs.PaymentOperationDTOs;
namespace clinicAPIsSystem.DTOs.UserDTOs.PatientDTO
{
    public class PatientDetailsDto:ApplicationUserDto
    {
        public ICollection<AppointmentDto> Appointments { get; private set; }
        public ICollection<PaymentOperationDto> PaymentOperation { get; private set; }
        public PatientDetailsDto(int id, string userName, string email, string firstName, string lastName, string phoneNumber, ICollection<AppointmentDto> appointments, ICollection<PaymentOperationDto> paymentOperations)
            : base(id, userName, email, firstName, lastName, phoneNumber)
        {
            Appointments = appointments;
            PaymentOperation = paymentOperations;
        }





    }
}
