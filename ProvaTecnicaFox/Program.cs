using Microsoft.EntityFrameworkCore;
using ProvaTecnicaFox.api.Controllers;
using ProvaTecnicaFox.Core.Context;
using static ProvaTecnicaFox.Core.Context.SqlContext;

namespace ProvaTecnicaFox
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

            var services = builder.Services;
            var env = builder.Environment;


            services.AddDbContext<SqlContext>();

            builder.Services.AddTransient<AccomodationController>();
            builder.Services.AddTransient<PriceListController>();
            builder.Services.AddTransient<RoomController>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetRequiredService<SqlContext>();
                dataContext.Database.Migrate();
            }

            app.UseSwagger();
            app.UseSwaggerUI();
            

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}