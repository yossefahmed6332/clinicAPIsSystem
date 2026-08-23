using clinicAPIsSystem.Models.User.Employee.Graduated.NonMedicalStaff;

namespace clinicAPIsSystem.Models
{
    public class FinancialReport
    {
        public int Id { get; private set; } 
        public decimal MonthlyExpenses { get; private set; }
        public decimal NetProfit { get; private set; }
        public decimal MonthlyRevenue { get; private set; }

        public FinancialReport() { }
        public FinancialReport(decimal monthlyExpenses, decimal netProfit, decimal monthlyRevenue)
        {
            MonthlyExpenses = monthlyExpenses;
            NetProfit = netProfit;
            MonthlyRevenue = monthlyRevenue;
        }



    }
}
