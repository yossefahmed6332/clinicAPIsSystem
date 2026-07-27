using clinicAPIsSystem.Data;
using clinicAPIsSystem.Interfaces;
using clinicAPIsSystem.ClinicDTOs.OperationDtos;
using clinicAPIsSystem.Models;
using Microsoft.EntityFrameworkCore;
namespace clinicAPIsSystem.Services
{
    public class OperationService:IOperationService
    {
        private readonly ClinicDbContext _context;
        public OperationService(ClinicDbContext context)
        {
            _context = context;
        }

        //create 
        public async Task AddOperationAsync(CreateOperationDto dto)
        {
            var operation = new Operation
            {
                AccountantId=dto.AccountantId,
                PatientId= dto.PatientId,
                AppointmentId = dto.AppointmentId,
                Amount= dto.Amount,
            };
            await _context.TOperations.AddAsync(operation);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OperationDto>> GetAllOperationsAsync()
        {
            var operations = await _context.TOperations.ToListAsync();
            if (operations.Count == 0)
            {
                throw new Exception("No operations found.");
            }
            return operations.Select(o => new OperationDto
            {
                Id = o.Id,
                AccountantId = o.AccountantId,
                PatientId = o.PatientId,
                AppointmentId = o.AppointmentId,
                Amount = o.Amount
            });
        }

        public async Task<OperationDto> GetOperationByIdAsync(int id)
        {
            var operation = await _context.TOperations.FindAsync(id);
            if (operation == null)
            {
                throw new Exception($"Operation with ID {id} not found.");
            }
            return new OperationDto
            {
                Id = operation.Id,
                AccountantId = operation.AccountantId,
                PatientId = operation.PatientId,
                AppointmentId = operation.AppointmentId,
                Amount = operation.Amount
            };
        }


        public async Task<IEnumerable<OperationDto>> GetOperationsByPatientIdAsync(int patientId)
        {
            var operations = await _context.TOperations
                .Where(o => o.PatientId == patientId)
                .ToListAsync();
            if (operations.Count == 0)
            {
                throw new Exception($"No operations found for patient with ID {patientId}.");
            }
            return operations.Select(o => new OperationDto
            {
                Id = o.Id,
                AccountantId = o.AccountantId,
                PatientId = o.PatientId,
                AppointmentId = o.AppointmentId,
                Amount = o.Amount
            });
        }
        public async Task<IEnumerable<OperationDto>> GetOperationsByAccountantIdAsync(int accountantId)
        {
            var operations = await _context.TOperations
                .Where(o => o.AccountantId == accountantId)
                .ToListAsync();
            if (operations.Count == 0)
            {
                throw new Exception($"No operations found for accountant with ID {accountantId}.");
            }
            return operations.Select(o => new OperationDto
            {
                Id = o.Id,
                AccountantId = o.AccountantId,
                PatientId = o.PatientId,
                AppointmentId = o.AppointmentId,
                Amount = o.Amount
            });
        }
        public async Task<IEnumerable<OperationDto>> GetOperationsByAppointmentIdAsync(int appointmentId)
        {
            var operations = await _context.TOperations
                .Where(o => o.AppointmentId == appointmentId)
                .ToListAsync();
            if (operations.Count == 0)
            {
                throw new Exception($"No operations found for appointment with ID {appointmentId}.");
            }
            return operations.Select(o => new OperationDto
            {
                Id = o.Id,
                AccountantId = o.AccountantId,
                PatientId = o.PatientId,
                AppointmentId = o.AppointmentId,
                Amount = o.Amount
            });
        }

        public async Task DeleteOperationAsync(int operationId)
        {
            var operation = await _context.TOperations.FindAsync(operationId);
            if (operation == null)
            {
                throw new Exception($"Operation with ID {operationId} not found.");
            }
            _context.TOperations.Remove(operation);
            await _context.SaveChangesAsync();
        }


    }
}
