using HealthcareAppointment.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointment.Business
{
    public interface IAppointmentService
    {
        Task ScheduleAppointmentAsync(Appointment appointment);
        Task CancelAppointmentAsync(Guid appointmentId);
        Task<Appointment> GetAppointmentDetailsAsync(Guid appointmentId);
    }
}
