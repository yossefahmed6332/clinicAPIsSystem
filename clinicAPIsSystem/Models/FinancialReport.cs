using clinicAPIsSystem.Models.User.Employee.Graduated.NonMedicalStaff;

namespace clinicAPIsSystem.Models
{
    public class FinancialReport
    {
        public int Id { get; set; } 
        public decimal MonthlyIncome { get; set; } 
        public Accountant? Accountant { get; set; } 
        public int? AccountantId { get; set; }
        public Manager? Manager { get; set; } 
        public int ? ManagerId { get; set; }

    }
}
