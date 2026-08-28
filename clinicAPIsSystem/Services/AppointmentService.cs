using AutoMapper;
using clinicAPIsSystem.DTOs.AppointmentDTOs;
using clinicAPIsSystem.IService;
using clinicAPIsSystem.Models;
using clinicAPIsSystem.IRepositoryService;
using clinicAPIsSystem.IServices.IUserServices;

namespace clinicAPIsSystem.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper, IUserService userService)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<AppointmentDto> CreateAppointmentAsync(CreateAppointmentDto createAppointmentDto)
        {
            //check if the appointment is in the past 
            if (createAppointmentDto.StartDate < DateTime.Now)
            {
                throw new ArgumentException("Appointment cannot be created in the past");
            }

            //check if the doctor has ather appointment in the same time range
            if (await _appointmentRepository.GetAppointmentInTimeRange(createAppointmentDto.StartDate, createAppointmentDto.EndDate, createAppointmentDto.DoctorId, createAppointmentDto.NurseId) != null)
            {
                throw new ArgumentException("Doctor is not available in the given time range");
            }

            var appointment = new Appointment(createAppointmentDto.StartDate
                ,createAppointmentDto.EndDate
                ,createAppointmentDto.PatientId
                ,createAppointmentDto.NurseId
                ,createAppointmentDto.DoctorId);


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


        public async Task<List<AppointmentDto>> GetAppointmentsByDoctorIdAsync(int doctorId)
        {
            var appointments = await _appointmentRepository.GetAppointmentsByDoctorIdAsync(doctorId);
            return _mapper.Map<List<AppointmentDto>>(appointments);
        }
        public async Task<List<AppointmentDto>> GetAppointmentsByPatientIdAsync(int patientId)
        {
            var appointments = await _appointmentRepository.GetAppointmentsByPatientIdAsync(patientId);
            return _mapper.Map<List<AppointmentDto>>(appointments);
        }
        public async Task<List<AppointmentDto>> GetAppointmentsByNurseIdAsync(int nurseId)
        {
            var appointments = await _appointmentRepository.GetAppointmentsByNurseIdAsync(nurseId);
            return _mapper.Map<List<AppointmentDto>>(appointments);
        }





        public async Task<List<AppointmentDto>> GetAppointmentsByStatusAsync(AppointmentStatus status)
        {
            var appointments = await _appointmentRepository.GetAppointmentsByStatusAsync(status);
            
            return _mapper.Map<List<AppointmentDto>>(appointments);
        }

        public async Task<List<AppointmentDto>> GetAppointmentsForUserByTokens(string token)
        {
            var user = await _userService.GetIdFromTokensAsync(token);
            return _mapper.Map<List<AppointmentDto>>(await _appointmentRepository.GetAppointmentsForUser(user));

        }
        public async Task<AppointmentDto> UpdateAppointmentAsync(
            UpdateAppointmentDto updateAppointmentDto,
            int id)
        {

            



            var appointment = await _appointmentRepository.GetAppointmentAsync(id);
            //check if appointment == null 
            if (appointment == null)
            {
                throw new KeyNotFoundException(
                    $"Appointment with ID {id} not found.");
            }

            if (updateAppointmentDto.StartDate!=appointment.StartDate||updateAppointmentDto.EndDate!= appointment.EndDate|| updateAppointmentDto.DoctorId != appointment.DoctorId|| updateAppointmentDto.NurseId != appointment.NurseId)
            {
                //check if the appointment is in the past 
                if (updateAppointmentDto.StartDate < DateTime.Now)
                {
                    throw new ArgumentException("Appointment cannot be created in the past");
                }

                //check if the doctor has ather appointment in the same time range
                if (await _appointmentRepository.GetAppointmentInTimeRange(updateAppointmentDto.StartDate, updateAppointmentDto.EndDate, updateAppointmentDto.DoctorId, updateAppointmentDto.NurseId) != null)
                {
                    throw new ArgumentException("Doctor is not available in the given time range");
                }
            }



            appointment.Update(
                updateAppointmentDto.StartDate,
                updateAppointmentDto.EndDate,
                updateAppointmentDto.Status,
                updateAppointmentDto.NurseId,
                updateAppointmentDto.PatientId,
                updateAppointmentDto.DoctorId
            );
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
