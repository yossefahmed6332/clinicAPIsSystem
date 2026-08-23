
namespace clinicAPIsSystem.DTOs.FinanialReportDTOs
{
    public class FinantialReportDto
    {
        public int Id { get; private set; }
        public decimal MonthlyExpenses { get; private set; }
        public decimal MonthlyRevenue { get; private set; }
        public decimal NetProfit { get; private set; }
        public DateTime Date { get; private set; } = DateTime.Now;


        public FinantialReportDto(int id, decimal monthlyExpenses, decimal monthlyRevenue, decimal netProfit, DateTime date)
        {
            Id = id;
            MonthlyExpenses = monthlyExpenses;
            MonthlyRevenue = monthlyRevenue;
            NetProfit = netProfit;
            Date = date;
        }
    }
}
