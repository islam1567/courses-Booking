using Bookink_Courses.Models.Context;
using Bookink_Courses.Models.DTOs;
using Bookink_Courses.Models.Interfaces;
using Bookink_Courses.Models.Repository;
using Bookink_Courses.Models.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bookink_Courses
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationDbContext>(e =>
            e.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=BookingCoursesDB;Integrated Security=True"));

            builder.Services.AddIdentity<ApplicationUser,IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddAutoMapper(typeof(StartupBase));

            builder.Services.AddScoped<IRepository<CourseDto>, Course_Repo>();
            builder.Services.AddScoped<IRepository<CatagoryDto>, Catagory_Repo>();
            builder.Services.AddScoped<IRepository<LessonDto>, Lesson_Repo>();
            builder.Services.AddScoped<IRepository<TrainerDto>, Trainer_Repo>();
            builder.Services.AddScoped<IRepository<Course_Trainer_Dto>, Course_Trainer_Repo>();
            builder.Services.AddScoped<IAuth, AuthService>();

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
