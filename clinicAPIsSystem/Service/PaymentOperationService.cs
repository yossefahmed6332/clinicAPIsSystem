using clinicAPIsSystem.IService;
using AutoMapper;
using clinicAPIsSystem.IRepositoryService;
using clinicAPIsSystem.DTOs.PaymentOperationDTOs;
using clinicAPIsSystem.Models;

namespace clinicAPIsSystem.Service
{
    public class PaymentOperationService:IPaymentOperationService
    {
        private readonly IPaymentOperationRepository _paymentOperationRepository;
        private readonly IMapper _mapper;
        public PaymentOperationService(IPaymentOperationRepository paymentOperationRepository, IMapper mapper)
        {
            _paymentOperationRepository = paymentOperationRepository;
            _mapper = mapper;
        }

        public async Task<PaymentOperationDto> CreatePaymentOperationAsync(CreatePaymentOperationDto createPaymentOperationDto)
        {
            var paymentOperation = _mapper.Map<PaymentOperation>(createPaymentOperationDto);
            var createdPaymentOperation = await _paymentOperationRepository.CreatePaymentOperationAsync(paymentOperation);
            return _mapper.Map<PaymentOperationDto>(createdPaymentOperation);
        }

        public async Task<List<PaymentOperationDto>> GetAllPaymentOperationsAsync()
        {
            var paymentOperations = await _paymentOperationRepository.GetAllPaymentOperationsAsync();
            return _mapper.Map<List<PaymentOperationDto>>(paymentOperations);
        }

        public async Task<PaymentOperationDto> GetPaymentOperationAsync(int id)
        {
            var paymentOperation = await _paymentOperationRepository.GetPaymentOperationAsync(id);
            return _mapper.Map<PaymentOperationDto>(paymentOperation);
        }

        public async Task<List<PaymentOperationDto>> GetPaymentOperationsByPatientIdAsync(int patientId)
        {
            var paymentOperations = await _paymentOperationRepository.GetPaymentOperationsByPatientIdAsync(patientId);
            return _mapper.Map<List<PaymentOperationDto>>(paymentOperations);
        }

        public async Task<List<PaymentOperationDto>> GetPaymentOperationsByAccountantIdAsync(int accountantId)
        {
            var paymentOperations = await _paymentOperationRepository.GetPaymentOperationsByAccountantIdAsync(accountantId);
            return _mapper.Map<List<PaymentOperationDto>>(paymentOperations);
        }

    }
}
