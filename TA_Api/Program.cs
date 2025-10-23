using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TA.Domain.Services;
using TA.Domain.Services.Interfaces;
using TA.Persistence;
using TA.Persistence.Entities;
using TA.Persistence.Interfaces;

namespace TA.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("treinAbonnementConnection");
            var serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect(connectionString));
            builder.Services.AddDbContext<TreinabonnementContext>(options => options.UseMySql(connectionString, serverVersion));

            builder.Services.AddControllers().AddJsonOptions(opt => { opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });

            builder.Services.AddScoped<IKlantService, KlantService>();
            builder.Services.AddScoped<IKlantRepository, KlantRepository>();

            builder.Services.AddScoped<IStationService, StationService>();
            builder.Services.AddScoped<IStationRepository, StationRepository>();

            builder.Services.AddScoped<IAbonnementService, AbonnementService>();
            builder.Services.AddScoped<IAbonnementRepository, AbonnementRepository>();

            builder.Services.AddControllers();

            var app = builder.Build();

            app.MapControllers();

            app.Run();
        }
    }
}
