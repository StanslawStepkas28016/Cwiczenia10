using Cwiczenia10.Entities;
using Cwiczenia10.Repositories;
using Cwiczenia10.Services;
using Microsoft.EntityFrameworkCore;

namespace Cwiczenia10;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        builder.Services.AddScoped<IHospitalRepository, HospitalRepository>();
        builder.Services.AddScoped<IHospitalService, HospitalService>();

        builder.Services.AddDbContext<HospitalDbContext>(opt =>
        {
            var connectionString = builder
                .Configuration
                .GetConnectionString("DefaultConnection");
            opt.UseSqlServer(connectionString);
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.MapControllers();

        app.Run();
    }
}