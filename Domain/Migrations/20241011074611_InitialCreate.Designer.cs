﻿// <auto-generated />
using System;
using HealthcareAppointment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HealthcareAppointment.Data.Migrations
{
    [DbContext(typeof(HealthcareAppointmentContext))]
    [Migration("20241011074611_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HealthcareAppointment.Models.Entities.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("HealthcareAppointment.Models.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Specialization")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1e91b2ca-a53b-435f-bf22-ab2073821aa3"),
                            DateOfBirth = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "john.doe@example.com",
                            Name = "John Doe",
                            Password = "Password123!",
                            Role = 0
                        },
                        new
                        {
                            Id = new Guid("c59afdda-00b3-42ba-9da6-718c3ca5550e"),
                            DateOfBirth = new DateTime(1985, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jane.smith@example.com",
                            Name = "Jane Smith",
                            Password = "Password123!",
                            Role = 0
                        },
                        new
                        {
                            Id = new Guid("af65d565-9ba8-4201-949a-d03c2b9da598"),
                            DateOfBirth = new DateTime(1975, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "alice.doctor@example.com",
                            Name = "Dr. Alice",
                            Password = "DoctorPass1!",
                            Role = 1,
                            Specialization = "Cardiology"
                        },
                        new
                        {
                            Id = new Guid("19be825c-cd97-4bde-9639-0f635f86d6d3"),
                            DateOfBirth = new DateTime(1970, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "bob.doctor@example.com",
                            Name = "Dr. Bob",
                            Password = "DoctorPass2!",
                            Role = 1,
                            Specialization = "Dermatology"
                        },
                        new
                        {
                            Id = new Guid("431f8118-1750-4a1a-bc3c-413d7d422811"),
                            DateOfBirth = new DateTime(1980, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "carol.doctor@example.com",
                            Name = "Dr. Carol",
                            Password = "DoctorPass3!",
                            Role = 1,
                            Specialization = "Pediatrics"
                        });
                });

            modelBuilder.Entity("HealthcareAppointment.Models.Entities.Appointment", b =>
                {
                    b.HasOne("HealthcareAppointment.Models.Entities.User", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HealthcareAppointment.Models.Entities.User", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HealthcareAppointment.Models.Entities.User", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
