using InvoiceManagementApp.Application.Common.Interfaces;
using InvoiceManagementApp.Infrastructure.Data;
using InvoiceManagementApp.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InvoiceManagementApp.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("Connect")!
        , m => m.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        return services;
    }
}
