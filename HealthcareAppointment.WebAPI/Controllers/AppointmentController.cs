using HealthcareAppointment.Business;
using HealthcareAppointment.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareAppointment.WebAPI.Controllers
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

        [HttpPost]
        public async Task<ActionResult> ScheduleAppointment(Appointment appointment)
        {
            await _appointmentService.ScheduleAppointmentAsync(appointment);
            return CreatedAtAction(nameof(GetAppointmentDetails), new { appointmentId = appointment.Id }, appointment);
        }

        [HttpDelete("{appointmentId}")]
        public async Task<ActionResult> CancelAppointment(Guid appointmentId)
        {
            await _appointmentService.CancelAppointmentAsync(appointmentId);
            return NoContent();
        }

        [HttpGet("{appointmentId}")]
        public async Task<ActionResult<Appointment>> GetAppointmentDetails(Guid appointmentId)
        {
            var appointment = await _appointmentService.GetAppointmentDetailsAsync(appointmentId);
            if (appointment == null)
                return NotFound();
            return Ok(appointment);
        }
    }
}
