using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using DataAccess.Implementations;
using DataAccess.Repositories;

namespace PayVortex
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfraStructureServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            return services;
        }

        public static IServiceCollection AddApplicationCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}