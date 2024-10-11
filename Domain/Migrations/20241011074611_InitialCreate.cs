using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthcareAppointment.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Users_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Users_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateOfBirth", "Email", "Name", "Password", "Role", "Specialization" },
                values: new object[,]
                {
                    { new Guid("19be825c-cd97-4bde-9639-0f635f86d6d3"), new DateTime(1970, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob.doctor@example.com", "Dr. Bob", "DoctorPass2!", 1, "Dermatology" },
                    { new Guid("1e91b2ca-a53b-435f-bf22-ab2073821aa3"), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John Doe", "Password123!", 0, null },
                    { new Guid("431f8118-1750-4a1a-bc3c-413d7d422811"), new DateTime(1980, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "carol.doctor@example.com", "Dr. Carol", "DoctorPass3!", 1, "Pediatrics" },
                    { new Guid("af65d565-9ba8-4201-949a-d03c2b9da598"), new DateTime(1975, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "alice.doctor@example.com", "Dr. Alice", "DoctorPass1!", 1, "Cardiology" },
                    { new Guid("c59afdda-00b3-42ba-9da6-718c3ca5550e"), new DateTime(1985, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane Smith", "Password123!", 0, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
