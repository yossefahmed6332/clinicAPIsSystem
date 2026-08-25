using System.ComponentModel.DataAnnotations;

namespace clinicAPIsSystem.DTOs.FinanialReportDTOs
{
    public class CreateFinancialReportDto
    {
        [Required, Range(0, double.MaxValue)]
        public decimal MonthlyExpenses { get; private set; }
        [Required, Range(0, double.MaxValue)]
        public decimal MonthlyRevenue { get;private set; }
        [Range(0, double.MaxValue)]
        public decimal NetProfit { get;private set; } 
        [Required]
        public DateTime Date { get;private set; } = DateTime.Now;

        public CreateFinancialReportDto(decimal monthlyExpenses, decimal monthlyRevenue, decimal netProfit, DateTime date)
        {
            MonthlyExpenses = monthlyExpenses;
            MonthlyRevenue = monthlyRevenue;
            NetProfit = netProfit;
            Date = date;
        }


    }
}
