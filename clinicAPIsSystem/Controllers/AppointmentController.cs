using clinicAPIsSystem.ClinicDTOs.AppointmentDTOs;
using clinicAPIsSystem.Interfaces;
using clinicAPIsSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace clinicAPIsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [Authorize(Roles = $"{nameof(Roles.Admin)},{nameof(Roles.Receptionist)}")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentDto appointment)
        {
            await _appointmentService.CreateAppointmentAsync(appointment);
            return NoContent();
        }

        [Authorize(Roles = $"{nameof(Roles.Admin)},{nameof(Roles.Receptionist)}")]
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllAppointments()
        {
            var appointments = await _appointmentService.GetAllAppointmentsAsync();
            return Ok(appointments);
        }
        [Authorize(Roles = $"{nameof(Roles.Admin)},{nameof(Roles.Receptionist)}")]
        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetAppointmentById(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }
        [Authorize(Roles = $"{nameof(Roles.Admin)},{nameof(Roles.Receptionist)}")]
        [HttpGet("get-by-doctor-id/{doctorId}")]
        public async Task<IActionResult> GetAppointmentByDoctorId(int doctorId)
        {
            var appointments = await _appointmentService.GetAppointmentsByDoctorIdAsync(doctorId);
            return Ok(appointments);
        }

        //get appointments by patient id for admin and receptionist
        [Authorize(Roles = $"{nameof(Roles.Admin)},{nameof(Roles.Receptionist)}")]
        [HttpGet("get-by-patient-id/{id}")]
        public async Task<IActionResult> GetAppointmentByPatientId(int id)
        {
            var appointments = await _appointmentService.GetAppointmentsByPatientIdAsync(id);
            return Ok(appointments);
        }


        //get appointments for current user (patient) by patient id 
        [Authorize(Roles = $"{nameof(Roles.Patient)}")]
        [HttpGet("get-by-patient-id")]
        public async Task<IActionResult> GetAppointmentsForCurrentUser()
        {
            var patientId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var appointments = await _appointmentService.GetAppointmentsByPatientIdAsync(patientId);
            return Ok(appointments);
        }

        [Authorize(Roles = $"{nameof(Roles.Admin)},{nameof(Roles.Receptionist)}")]
        [HttpGet("get-by-patient-and-doctor/{patientId}/{doctorId}")]
        public async Task<IActionResult> GetAppointmentsByPatientAndDoctor(int patientId, int doctorId)
        {
            var appointments = await _appointmentService.GetAppointmentsByPatientAndDoctorAsync(patientId, doctorId);
            return Ok(appointments);
        }

        [Authorize(Roles = $"{nameof(Roles.Admin)},{nameof(Roles.Receptionist)}")]
        [HttpGet("get-by-status/{status}")]
        public async Task<IActionResult> GetAppointmentsByStatus(AppointmentStatus status)
        {
            var appointments = await _appointmentService.GetAppointmentsByStatusAsync(status);
            return Ok(appointments);
        }

        // Update appointment
        [Authorize(Roles = $"{nameof(Roles.Admin)},{nameof(Roles.Receptionist)}")]
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, [FromBody] UpdateAppointmentDto appointment)
        {
            await _appointmentService.UpdateAppointmentAsync(id, appointment);
            return NoContent();
        }
        [Authorize(Roles = $"{nameof(Roles.Admin)},{nameof(Roles.Receptionist)}")]
        [HttpPut("delete-appointment/{appointmentId}")]
        public async Task<IActionResult> DeleteAppointment(int appointmentId)
        {
            await _appointmentService.DeleteAppointmentAsync(appointmentId);
            return NoContent();
        }



    }
}
