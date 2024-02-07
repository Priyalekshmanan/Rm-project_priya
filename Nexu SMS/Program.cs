
using Nexu_SMS.Entity;
using Nexu_SMS.Repository;

namespace Nexu_SMS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddTransient<AdmissionRepo>();
            builder.Services.AddDbContext<ContextClass>();
            builder.Services.AddTransient<StudentRepo>();
            builder.Services.AddTransient<UsersRepo>();
            builder.Services.AddTransient<TeacherRepo>();
            builder.Services.AddTransient<SAttendanceRepo>();
            builder.Services.AddTransient<TAttandanceRepo>();
            builder.Services.AddTransient<ClassManagementRepo>();
            builder.Services.AddTransient<ExamRepo>();
            builder.Services.AddTransient<ResultRepo>();


            builder.Services.AddControllers();
            builder.Services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options =>
                {
                    options.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.UseCors("AllowOrigin");
            app.MapControllers();

            app.Run();
        }
    }
}
