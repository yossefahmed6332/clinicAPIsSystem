using AutoMapper;
using clinicAPIsSystem.DTOs.AppointmentDTOs;
using clinicAPIsSystem.IService;
using clinicAPIsSystem.Models;
using clinicAPIsSystem.RepositoryService;

namespace clinicAPIsSystem.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly AppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;
        public AppointmentService(AppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task<AppointmentDto> CreateAppointmentAsync(CreateAppointmentDto createAppointmentDto)
        {
            var appointment = _mapper.Map<Appointment>(createAppointmentDto);

            appointment =await _appointmentRepository.CreateAppointmentAsync(appointment);
            return _mapper.Map<AppointmentDto>(appointment);
        }

        public async Task<List<AppointmentDto>> GetAllAppointmentsAsync()
        {
            var appointments = await _appointmentRepository.GetAllAppointmentsAsync();

            return _mapper.Map<List<AppointmentDto>>(appointments);
        }

        public async Task<AppointmentDto> GetAppointmentAsync(int id)
        {
            var appointment = await _appointmentRepository.GetAppointmentAsync(id);
            if (appointment == null)
            {
                throw new KeyNotFoundException($"Appointment with ID {id} not found.");
            }
            return _mapper.Map<AppointmentDto>(appointment);
        }
        public async Task<List<AppointmentDto>> GetAppointmentsByStatusAsync(AppointmentStatus status)
        {
            var appointments = await _appointmentRepository.GetAppointmentsByStatusAsync(status);
            
            return _mapper.Map<List<AppointmentDto>>(appointments);
        }
        public async Task<AppointmentDto> UpdateAppointmentAsync(
            UpdateAppointmentDto updateAppointmentDto,
            int id)
        {
            var appointment = await _appointmentRepository.GetAppointmentAsync(id);

            if (appointment == null)
            {
                throw new KeyNotFoundException(
                    $"Appointment with ID {id} not found.");
            }

            _mapper.Map(updateAppointmentDto, appointment);

            appointment = await _appointmentRepository
                .UpdateAppointmentAsync(appointment);

            return _mapper.Map<AppointmentDto>(appointment);
        }
        public async Task DeleteAppointmentAsync(int id)
        {
            var appointment = await _appointmentRepository.GetAppointmentAsync(id);
            if (appointment == null)
            {
                throw new KeyNotFoundException($"Appointment with ID {id} not found.");
            }
            await _appointmentRepository.DeleteAppointmentAsync(appointment);
        }
    }
}
