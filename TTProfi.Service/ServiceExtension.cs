using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TTProfi.Data;
using TTProfi.Service.Interfaces;
using TTProfi.Service.Services;

namespace TTProfi.Service
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TTContext>(options => options.UseSqlServer(configuration.GetConnectionString("TTProfiConnection")));

            services.AddScoped<ITournamentService, TournamentService>();
        }
    }
}
