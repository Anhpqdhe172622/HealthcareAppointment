using HealthcareAppointment.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointment.Data
{
    public class HealthcareAppointmentContext : DbContext
    {
        public HealthcareAppointmentContext(DbContextOptions<HealthcareAppointmentContext> options)
        : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;database=Test10_10;uid=sa;pwd=123;TrustServerCertificate=true"); // Thay bằng chuỗi kết nối của bạn
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Fluent API for User
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<User>()
                .Property(u => u.Specialization)
                .HasMaxLength(255);

            modelBuilder.Entity<User>()
                .Property(u => u.DateOfBirth)
                .HasColumnType("date");

            // Configure Fluent API for Appointment
            modelBuilder.Entity<Appointment>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Appointment>()
                .Property(a => a.Date)
                .IsRequired();

            modelBuilder.Entity<Appointment>()
                .Property(a => a.Status)
                .IsRequired();

            // Configure relationships
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(u => u.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany()
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed data
            modelBuilder.Entity<User>().HasData(
    new User
    {
        Id = Guid.NewGuid(),
        Name = "John Doe",
        Email = "john.doe@example.com",
        DateOfBirth = new DateTime(1990, 1, 1),
        Password = "Password123!",
        Role = UserRole.Patient,
        Specialization = null // Không cần giá trị cho bệnh nhân
    },
    new User
    {
        Id = Guid.NewGuid(),
        Name = "Jane Smith",
        Email = "jane.smith@example.com",
        DateOfBirth = new DateTime(1985, 5, 5),
        Password = "Password123!",
        Role = UserRole.Patient,
        Specialization = null // Không cần giá trị cho bệnh nhân
    },
    new User
    {
        Id = Guid.NewGuid(),
        Name = "Dr. Alice",
        Email = "alice.doctor@example.com",
        DateOfBirth = new DateTime(1975, 3, 20),
        Password = "DoctorPass1!",
        Role = UserRole.Doctor,
        Specialization = "Cardiology" // Cung cấp giá trị cho bác sĩ
    },
    new User
    {
        Id = Guid.NewGuid(),
        Name = "Dr. Bob",
        Email = "bob.doctor@example.com",
        DateOfBirth = new DateTime(1970, 12, 12),
        Password = "DoctorPass2!",
        Role = UserRole.Doctor,
        Specialization = "Dermatology" // Cung cấp giá trị cho bác sĩ
    },
    new User
    {
        Id = Guid.NewGuid(),
        Name = "Dr. Carol",
        Email = "carol.doctor@example.com",
        DateOfBirth = new DateTime(1980, 8, 15),
        Password = "DoctorPass3!",
        Role = UserRole.Doctor,
        Specialization = "Pediatrics" // Cung cấp giá trị cho bác sĩ
    }
);

        }
    }
}
