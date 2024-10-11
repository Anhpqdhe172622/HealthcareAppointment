using HealthcareAppointment.Data.Repositories;
using HealthcareAppointment.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointment.Business
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task ScheduleAppointmentAsync(Appointment appointment)
        {
            // Thêm logic xác thực nếu cần
            await _appointmentRepository.AddAppointmentAsync(appointment);
        }

        public async Task CancelAppointmentAsync(Guid appointmentId)
        {
            await _appointmentRepository.DeleteAppointmentAsync(appointmentId);
        }

        public async Task<Appointment> GetAppointmentDetailsAsync(Guid appointmentId)
        {
            return await _appointmentRepository.GetAppointmentByIdAsync(appointmentId);
        }
    }
}
