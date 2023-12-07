using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
namespace School.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }

}
