using System.ComponentModel.DataAnnotations;

namespace clinicAPIsSystem.DTOs.OperationDTOs
{
    public class CreateOperationDto
    {
        [Required, Range(0.01, double.MaxValue)]
        public decimal Amount { get; private set; }
        [Required]
        public DateTime Date { get; private set; }
        [Required, EnumDataType(typeof(OperationType))]
        public OperationType OperationType { get; private set; }
        [Required, EnumDataType(typeof(OperationStatus))]
        public OperationStatus OperationStatus { get; private set; }
        [Range(1, int.MaxValue)]
        public int? PatientId { get; private set; }
        [Range(1, int.MaxValue)]
        public int? AccountantId { get; private set; }
        [Required, EnumDataType(typeof(PaymentMethod))]
        public PaymentMethod PaymentMethod { get; private set; }

        public CreateOperationDto(decimal amount, DateTime date, OperationType operationType, OperationStatus operationStatus, int? patientId, int? accountantId, PaymentMethod paymentMethod)
        {
            Amount = amount;
            Date = date;
            OperationType = operationType;
            OperationStatus = operationStatus;
            PatientId = patientId;
            AccountantId = accountantId;
            PaymentMethod = paymentMethod;
        }
    }
}
