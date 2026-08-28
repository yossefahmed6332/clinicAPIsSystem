using clinicAPIsSystem.DTOs.PaymentOperationDTOs;
using clinicAPIsSystem.IService;
using Microsoft.AspNetCore.Mvc;

namespace clinicAPIsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentOperationController : ControllerBase
    {
        private readonly IPaymentOperationService _paymentOperationService;

        public PaymentOperationController(
            IPaymentOperationService paymentOperationService)
        {
            _paymentOperationService = paymentOperationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePaymentOperation(
            [FromBody] CreatePaymentOperationDto createPaymentOperationDto)
        {
            var createdPaymentOperation =
                await _paymentOperationService.CreatePaymentOperationAsync(
                    createPaymentOperationDto);

            return CreatedAtAction(
                nameof(GetPaymentOperation),
                new { id = createdPaymentOperation.Id },
                createdPaymentOperation);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPaymentOperations()
        {
            var paymentOperations =
                await _paymentOperationService.GetAllPaymentOperationsAsync();

            return Ok(paymentOperations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentOperation(int id)
        {
            var paymentOperation =
                await _paymentOperationService.GetPaymentOperationAsync(id);

            return Ok(paymentOperation);
        }

        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetPaymentOperationsByPatientId(
            int patientId)
        {
            var paymentOperations =
                await _paymentOperationService
                    .GetPaymentOperationsByPatientIdAsync(patientId);

            return Ok(paymentOperations);
        }

        [HttpGet("accountant/{accountantId}")]
        public async Task<IActionResult> GetPaymentOperationsByAccountantId(
            int accountantId)
        {
            var paymentOperations =
                await _paymentOperationService
                    .GetPaymentOperationsByAccountantIdAsync(accountantId);

            return Ok(paymentOperations);
        }
    }
}