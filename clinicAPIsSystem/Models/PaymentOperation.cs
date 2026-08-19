using clinicAPIsSystem.Models.User;
using clinicAPIsSystem.Models.User.Employee.Graduated.NonMedicalStaff;

namespace clinicAPIsSystem.Models
{
    public class PaymentOperation
    {
        public int Id { get; set; } 
        public decimal Amount { get; set; } 
        public DateTime Date { get; set; }
        public OperationType OperationType {  get; set; }
        public OperationStatus Status { get; set; } 
        public Patient? Patient { get; set; }
        public int ? PatientId { get; set;  }
        public Accountant ? Accountant { get; set; } 
        public int? AccountantId { get; set; } 
        public PaymentMethod PaymentMethod { get; set; } 

    }
}
