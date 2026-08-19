using Microsoft.VisualBasic;

namespace clinicAPIsSystem.Models.User.Employee.Graduated.NonMedicalStaff
{
    public class Accountant:NonMedicalStaff
    {
        public ICollection<PaymentOperation> PaymentOperations { get; set; } = new HashSet<PaymentOperation>(); 
    }
}
