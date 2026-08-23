namespace clinicAPIsSystem.DTOs.OperationDTOs
{
    public class OperationDto
    {
        public int Id { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }
        public OperationType OperationType { get; private set; }
        public OperationStatus OperationStatus { get; private set; }
        public int? PatientId { get; private set; }
        public int? AccountantId { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }

        public OperationDto(int id, decimal amount, DateTime date, OperationType operationType, OperationStatus operationStatus, int? patientId, int? accountantId, PaymentMethod paymentMethod)
        {
            Id = id;
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
