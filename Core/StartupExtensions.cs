using Core.Interfaces;
using Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class StartupExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<ITrackService, TrackService>();
            services.AddScoped<IAccountService, AccountService>();
        }
    }
}
