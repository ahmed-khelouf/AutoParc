using AutoParc.DataContext;
using AutoParc.DataSource;
using AutoParc.DataSource.Interface;
using AutoParc.Model.Identity;
using AutoParc.Senders;
using AutoParc.Senders.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AutoParc.WebUI.Config;

public static class ServicesExtensionMethods
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services,
        IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("AutoParcDb");
        services.AddDbContext<MainDbContext>(options => { options.UseSqlServer(connectionString); });

        services.AddIdentityCore<UserModel>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<MainDbContext>()
            .AddSignInManager<SignInManager<UserModel>>()
            .AddDefaultTokenProviders();

        services.AddAuthentication(o =>
        {
            o.DefaultScheme = IdentityConstants.ApplicationScheme;
            o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
        }).AddIdentityCookies(o => { });
        
        services.AddScoped<IMailSender, MailSender>();
        services.AddScoped<SignInDataSource>();
        services.AddScoped<UserDataSource>();
        
        services.AddScoped<IEntrepriseDataSource, EntrepriseDataSource>();
        services.AddScoped<IVehiculeDataSource, VehiculeDataSource>();
        services.AddScoped<IEmployeeDataSource, EmployeeDataSource>();
        
        return services;
    }
}