using Application.Abstractions;
using Domain.Abstractions;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {


        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("DefaultConnection"),
                providerOptions =>
                {
                    providerOptions.CommandTimeout(180);
                    providerOptions.EnableRetryOnFailure(
                       maxRetryCount: 5,                 // Maximum retry attempts before failing
                       maxRetryDelay: TimeSpan.FromSeconds(10), // Delay between retries
                       errorNumbersToAdd: null           // Add SQL error numbers to retry on, or leave null for default
                   );
                });
        });

        services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        
        services.Configure<Settings.MailSettings>(config.GetSection("MailSettings"));
        services.AddTransient<IEmailSender, EmailSender>();
        services.AddSingleton<IEmailTemplateService, EmailTemplateService>();

        services.AddMemoryCache();

        services.AddDistributedMemoryCache();
        return services;


    }

};
