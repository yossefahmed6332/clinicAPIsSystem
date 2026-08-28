using clinicAPIsSystem.DTOs.AppointmentDTOs;
using clinicAPIsSystem.IService;
using clinicAPIsSystem.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAppointment(
        [FromBody] CreateAppointmentDto appointment)
    {
        var createdAppointment =
            await _appointmentService.CreateAppointmentAsync(appointment);

        return CreatedAtAction(
            nameof(GetAppointmentById),
            new { id = createdAppointment.Id },
            createdAppointment);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAppointments()
    {
        var appointments =
            await _appointmentService.GetAllAppointmentsAsync();

        return Ok(appointments);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAppointmentById(int id)
    {
        var appointment =
            await _appointmentService.GetAppointmentAsync(id);

        return Ok(appointment);
    }

    [HttpGet("status/{status}")]
    public async Task<IActionResult> GetAppointmentsByStatus(AppointmentStatus status)
    {
        var appointments =
            await _appointmentService.GetAppointmentsByStatusAsync(status);

        return Ok(appointments);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAppointment(
        int id,
        [FromBody] UpdateAppointmentDto appointment)
    {
        var updatedAppointment =
            await _appointmentService.UpdateAppointmentAsync(appointment, id);

        return Ok(updatedAppointment);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAppointment(int id)
    {
        await _appointmentService.DeleteAppointmentAsync(id);

        return NoContent();
    }
}