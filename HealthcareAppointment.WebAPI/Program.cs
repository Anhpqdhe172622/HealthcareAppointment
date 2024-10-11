
using HealthcareAppointment.Business;
using HealthcareAppointment.Data;
using HealthcareAppointment.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAppointment.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Thêm dịch vụ DbContext và các repository, service vào DI container
            builder.Services.AddDbContext<HealthcareAppointmentContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // Đăng ký các repository và services
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            builder.Services.AddScoped<IAppointmentService, AppointmentService>();

            builder.Services.AddControllers(); // Đăng ký dịch vụ cho controller

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
