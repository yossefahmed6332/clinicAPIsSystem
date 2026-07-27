using clinicAPIsSystem.ClinicDTOs.OperationDtos;
using clinicAPIsSystem.Data;
using clinicAPIsSystem.Interfaces;
using clinicAPIsSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace clinicAPIsSystem.Services
{
    public class OperationService : IOperationService
    {
        private readonly ClinicDbContext _context;

        public OperationService(ClinicDbContext context)
        {
            _context = context;
        }


        public async Task AddOperationAsync(CreateOperationDto dto)
        {
            if (!await _context.TPatients.AnyAsync(p => p.Id == dto.PatientId))
                throw new KeyNotFoundException("Patient not found.");

            if (!await _context.TAppointments.AnyAsync(a => a.Id == dto.AppointmentId))
                throw new KeyNotFoundException("Appointment not found.");

            bool operationExists = await _context.TOperations
                .AnyAsync(o => o.AppointmentId == dto.AppointmentId);

            if (operationExists)
                throw new InvalidOperationException("This appointment already has an operation.");

            if (dto.Amount <= 0)
                throw new InvalidOperationException("Amount must be greater than zero.");

            var operation = new Operation
            {
                PatientId = dto.PatientId,
                AppointmentId = dto.AppointmentId,
                ReceptionistId = dto.ReceptionistId,
                Amount = dto.Amount
            };

            await _context.TOperations.AddAsync(operation);
            await _context.SaveChangesAsync();
        }



        public async Task<IEnumerable<OperationDto>> GetAllOperationsAsync()
        {
            var operations = await _context.TOperations
                .AsNoTracking()
                .ToListAsync();

            return operations.Select(MapToDto);
        }

        public async Task<OperationDto> GetOperationByIdAsync(int id)
        {
            var operation = await _context.TOperations
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == id);

            if (operation == null)
                throw new KeyNotFoundException($"Operation with ID {id} was not found.");

            return MapToDto(operation);
        }

        public async Task<IEnumerable<OperationDto>> GetOperationsByPatientIdAsync(int patientId)
        {
            var operations = await _context.TOperations
                .AsNoTracking()
                .Where(o => o.PatientId == patientId)
                .ToListAsync();

            return operations.Select(MapToDto);
        }

        public async Task<IEnumerable<OperationDto>> GetOperationsByReceptionistIdAsync(int receptionistId)
        {
            var operations = await _context.TOperations
                .AsNoTracking()
                .Where(o => o.ReceptionistId == receptionistId)
                .ToListAsync();

            return operations.Select(MapToDto);
        }

        public async Task<IEnumerable<OperationDto>> GetOperationsByAppointmentIdAsync(int appointmentId)
        {
            var operations = await _context.TOperations
                .AsNoTracking()
                .Where(o => o.AppointmentId == appointmentId)
                .ToListAsync();

            return operations.Select(MapToDto);
        }






        private static OperationDto MapToDto(Operation operation)
        {
            return new OperationDto
            {
                Id = operation.Id,
                PatientId = operation.PatientId,
                AppointmentId = operation.AppointmentId,
                ReceptionistId = operation.ReceptionistId,
                Amount = operation.Amount
            };
        }
    }
}