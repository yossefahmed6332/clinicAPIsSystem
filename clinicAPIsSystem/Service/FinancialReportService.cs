using AutoMapper;
using clinicAPIsSystem.IService;
using clinicAPIsSystem.DTOs.FinanialReportDTOs;
using clinicAPIsSystem.IRepositoryService;
using clinicAPIsSystem.Models;
namespace clinicAPIsSystem.Service
{
    public class FinancialReportService:IFinancialReportService
    {
        private readonly IFinancialReportRepository _financialReportRepository;
        private readonly IMapper _mapper;
        public FinancialReportService(IFinancialReportRepository financialReportRepository, IMapper mapper)
        {
            _financialReportRepository = financialReportRepository;
            _mapper = mapper;
        }

        public async Task<FinancialReportDto> CreateFinancialReportAsync(CreateFinancialReportDto createFinancialReportDto)
        {
            var financialReport = _mapper.Map<FinancialReport>(createFinancialReportDto);
            financialReport = await _financialReportRepository.CreateFinancialReportAsync(financialReport);
            return _mapper.Map<FinancialReportDto>(financialReport);
        }

        public async Task<List<FinancialReportDto>> GetAllFinancialReportsAsync()
        {
            var financialReports = await _financialReportRepository.GetAllFinancialReportsAsync();
            return _mapper.Map<List<FinancialReportDto>>(financialReports);
        }

        public async Task<FinancialReportDto> GetFinancialReportAsync(int id)
        {
            var financialReport = await _financialReportRepository.GetFinancialReportAsync(id);
            if (financialReport == null)
            {
                throw new KeyNotFoundException($"Financial report with ID {id} not found.");
            }
            return _mapper.Map<FinancialReportDto>(financialReport);
        }

        public async Task<List<FinancialReportDto>> GetFinancialReportsByRangeAsync(decimal min, decimal max, DateTime startDate, DateTime endDate)
        {
            var financialReports = await _financialReportRepository.GetFinancialReportsByRangeAsync(min, max, startDate, endDate);
            return _mapper.Map<List<FinancialReportDto>>(financialReports);
        }
        public async Task<List<FinancialReportDto>> GetFinancialReportsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var financialReports = await _financialReportRepository.GetFinancialReportsByDateRangeAsync(startDate, endDate);
            return _mapper.Map<List<FinancialReportDto>>(financialReports);
        }
    }
}
