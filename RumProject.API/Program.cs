
using Microsoft.EntityFrameworkCore;
using RumProject.API.Data;
using RumProject.API.Mappers;
using RumProject.API.Repositories;

namespace RumProject.API
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

            builder.Services.AddDbContext<RumProjectDBContext>(options => 
            options.UseSqlServer(builder.Configuration.GetConnectionString("RumProjectConnectionString")));


            builder.Services.AddScoped<IProvenanceRepository, SQLProvenanceRepository>();
            builder.Services.AddScoped<IAlcoholRepository, SQLAlcoholRepository>();

            builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

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
