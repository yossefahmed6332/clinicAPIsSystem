using clinicAPIsSystem.Models;

namespace clinicAPIsSystem.IRepositoryService
{
    public interface IFinancialReportRepository
    {
        public Task<FinancialReport> ICreateFinancialReportAsync();
        public Task<List<FinancialReport>> IGetAllFinancialReportsAsync();
        public Task<FinancialReport> IGetFinancialReportAsync(int id);
        public Task<List<FinancialReport>> IGetFinancialReportsByRangeAsync(decimal min, decimal max,DateTime startDate, DateTime endDate);
        public Task<List<FinancialReport>> IGetFinancialReportsByDateRangeAsync(DateTime startDate, DateTime endDate);
        public Task<FinancialReport> IUpdateFinancialReportAsync(FinancialReport financialReport);
        public Task IDeleteFinancialReportAsync(int id);
    }
}
