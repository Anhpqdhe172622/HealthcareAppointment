using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointment.Models.Entities
{
    public enum UserRole
    {
        Patient,
        Doctor
    }

    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }

        // Thay đổi cho phép giá trị null
        public string? Specialization { get; set; }

        // Thuộc tính để chứa danh sách các cuộc hẹn
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }


}
