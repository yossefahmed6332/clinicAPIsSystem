namespace clinicAPIsSystem.DTOs
{
    public enum AppointmentStatus
    {
        Scheduled,
        pending,
        confirmed,
        completed,
        canceled,
        NoShow

    }

    public enum OperationType
    {
        Payment,
        Refund,
        Salary,
        Expense
    }
    public enum OperationStatus
    {
        Pending,
        Completed,
        Failed
    }
    public enum PaymentMethod
    {
        Cash,
        Card,
        
        
    }
}
