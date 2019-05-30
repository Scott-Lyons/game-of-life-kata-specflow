using GameOfLife.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GameOfLife
{
    public static class Registry
    {
        public static void AddRegistry(this IServiceCollection services)
        {
            services.AddScoped<IRunner, Runner>();
            services.AddScoped<INeighbourCounter, NeighbourCounter>();
        }
    }
}
