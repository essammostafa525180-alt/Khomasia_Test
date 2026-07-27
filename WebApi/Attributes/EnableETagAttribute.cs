using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace WebApi.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class EnableETagAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            var executedContext = await next();

            if (executedContext.Result is not ObjectResult objectResult)
                return;

            if (objectResult.StatusCode is not null && objectResult.StatusCode != 200)
                return;

            var response = context.HttpContext.Response;

            // Serialize response بشكل ثابت
            var json = JsonSerializer.Serialize(
                objectResult.Value,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = false
                });

            // دخّل QueryString في الحساب (لغة – تشكيل – الخ)
            var query = context.HttpContext.Request.QueryString.Value ?? string.Empty;
            var contentToHash = json + query;

            var etag = GenerateETag(contentToHash);

            // لو العميل باعت If-None-Match
            if (context.HttpContext.Request.Headers.TryGetValue(
                HeaderNames.IfNoneMatch, out var requestEtag))
            {
                if (requestEtag == etag)
                {
                    executedContext.Result = new StatusCodeResult(StatusCodes.Status304NotModified);
                    return;
                }
            }

            response.Headers[HeaderNames.ETag] = etag;
        }

        private static string GenerateETag(string content)
        {
            using var sha = SHA256.Create();
            var hash = sha.ComputeHash(Encoding.UTF8.GetBytes(content));
            return $"\"{Convert.ToBase64String(hash)}\"";
        }
    }
}