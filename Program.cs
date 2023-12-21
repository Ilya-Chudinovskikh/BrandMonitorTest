using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BrandMonitorTest.Data;
using BrandMonitorTest.Services;
using BrandMonitorTest.Repositories;
using Microsoft.AspNetCore.Authentication.Certificate;
namespace BrandMonitorTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(
                CertificateAuthenticationDefaults.AuthenticationScheme)
                .AddCertificate();

            builder.Services.AddDbContext<BrandMonitorTestContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("BrandMonitorTestContext") ?? throw new InvalidOperationException("Connection string 'BrandMonitorTestContext' not found.")));

            builder.Services.AddControllers();

            builder.Services.AddScoped<ITaskService, TaskService>();
            builder.Services.AddScoped<ITaskRepository, TaskRepository>();

            var app = builder.Build();

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
