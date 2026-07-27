using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace Resources
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddResourceServices(this IServiceCollection services)
        {
            // Adds localization services
            services.AddLocalization();

            const string defaultCulture = "en";
            var supportedCultures = new[]
            {
                new CultureInfo(defaultCulture),
                new CultureInfo("ar")
            };

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture(defaultCulture);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            return services;
        }


        public static IApplicationBuilder UseResourceLocalization(this IApplicationBuilder app)
        {
            // Applies localization settings from the configured options
            var localizationOptions = app.ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value;
            app.UseRequestLocalization(localizationOptions);

            app.Use((context, next) =>
            {
                var clientLanguage = context.Request.Headers["Accept-Language"].ToString().ToLower();

                var defaultLanguage = "en";
                switch (clientLanguage)
                {
                    case "ar":
                    case var lang when lang.Contains("ar"):
                        defaultLanguage = "ar";
                        break;
                    default:
                        defaultLanguage = "en";
                        break;
                }

                Thread.CurrentThread.CurrentCulture = new CultureInfo(defaultLanguage);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(defaultLanguage);

                return next();
            });


            return app;
        }
    }
}
