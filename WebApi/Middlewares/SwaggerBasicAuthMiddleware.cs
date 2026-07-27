using System.Text;

namespace WebApi.Middlewares
{
    public class SwaggerBasicAuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public SwaggerBasicAuthMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/swagger") || context.Request.Path.StartsWithSegments("/Swagger"))
            {
                var section = _configuration.GetSection("SwaggerAuth");
                var configUsername = section["Username"];

                var now = DateTime.UtcNow;
                var sum = now.Day + now.Month + now.Year;
                var expectedPassword = sum.ToString();

                string authHeader = context.Request.Headers["Authorization"];

                if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Basic "))
                {
                    context.Response.Headers["WWW-Authenticate"] = "Basic";
                    context.Response.StatusCode = 401;
                    return;
                }

                var encodedCredentials = authHeader.Substring("Basic ".Length).Trim();
                var decodedCredentials = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCredentials));
                var parts = decodedCredentials.Split(':');

                if (parts.Length != 2)
                {
                    context.Response.StatusCode = 401;
                    return;
                }

                var username = parts[0];
                var password = parts[1];

                if (username != configUsername || password != expectedPassword)
                {
                    context.Response.StatusCode = 401;
                    return;
                }
            }

            await _next(context);
        }
    }

}
