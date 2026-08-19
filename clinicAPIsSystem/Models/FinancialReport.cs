using clinicAPIsSystem.Models.User.Employee.Graduated.NonMedicalStaff;

namespace clinicAPIsSystem.Models
{
    public class FinancialReport
    {
        public int Id { get; set; } 
        public decimal MonthlyExpenses { get; set; }
        public decimal NetProfit { get; set; }
        public decimal MonthlyRevenue { get; set; }


    }
}
