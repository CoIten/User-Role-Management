using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using System.Security;

namespace PayVortex
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCustomerServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IPermissionService, PermissionService>();

            return services;
        }
    }
}
