using Microsoft.AspNetCore.Http;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaMaster.Infrastructure.System
{
    public class LocalizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string defaultLanguage = "en-US"; // Set your default language here

        public LocalizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var acceptLanguageHeader = context.Request.Headers["Accept-Language"];

            // If Accept-Language header is null or empty, use the default language
            var preferredLanguage = !string.IsNullOrEmpty(acceptLanguageHeader)
                ? acceptLanguageHeader.ToString().Split(',').FirstOrDefault()?.Trim()
                : defaultLanguage;

            // Set the culture for the request
            var culture = new CultureInfo(preferredLanguage);
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;

            // Call the next middleware in the pipeline
            await _next(context);
        }
    }
}
