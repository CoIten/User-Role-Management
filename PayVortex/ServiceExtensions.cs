using BusinessLayer.Interfaces;
using BusinessLayer.Services;

namespace PayVortex
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddBusinessLayerServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IPermissionService, PermissionService>();

            return services;
        }
    }
}
