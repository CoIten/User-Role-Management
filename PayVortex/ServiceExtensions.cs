using BusinessLayer.Interfaces;
using BusinessLayer.Services;

namespace PayVortex
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCustomerServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();

            return services;
        }
    }
}
