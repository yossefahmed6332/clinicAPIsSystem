using clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO;

namespace clinicAPIsSystem.DTOs.UserDTOs.PatientDTO
{
    public class PatientDetailsDto:ApplicationUserDto
    {
        public ICollection<AppointmentDto> Appointments { get; private set; }
        public ICollection<PaymantOperationDto> PaymaentOperation { get; private set; }
        public PatientDetailsDto(int id, string userName, string email, string firstName, string lastName, string phoneNumber, ICollection<AppointmentDto> appointments, ICollection<PaymantOperationDto> paymentOperations)
            : base(id, userName, email, firstName, lastName, phoneNumber)
        {
            Appointments = appointments;
            PaymaentOperation = paymentOperations;
        }





    }
}
