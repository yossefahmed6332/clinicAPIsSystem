using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace clinicAPIsSystem.ClinicDTOs.OperationDtos
{
    public class CreateOperationDto
    {
        [Required, Range(1, int.MaxValue)]
        public int ReceptionistId { get; set; }
        [Required, Range(1, int.MaxValue)]
        public int PatientId { get; set; }
        [Required, Range(1, int.MaxValue)]
        public int AppointmentId { get; set; }
        [Required]
        public DateTime OperationDate { get; set; } = DateTime.Now; 
        [Required, Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }

    }
}
