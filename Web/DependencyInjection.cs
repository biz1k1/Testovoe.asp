using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Web.Services;

namespace Web
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            services.AddTransient<INumberOfDishes, NumberOfDishesService>();
            services.AddTransient<IServiceHandler, ServiceHandler>();
            return services;
        }
    }
}
