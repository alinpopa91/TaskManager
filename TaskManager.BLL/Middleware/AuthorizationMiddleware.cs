using Microsoft.AspNetCore.Http;

namespace TaskManager.BLL.Middleware
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _expectedApplicationKey;

        public AuthorizationMiddleware(RequestDelegate next, string expectedApplicationKey)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _expectedApplicationKey = expectedApplicationKey ?? throw new ArgumentNullException(nameof(expectedApplicationKey));
        }

        public async Task Invoke(HttpContext context)
        {
            var request = context.Request;

            if (request.Headers.TryGetValue("ApplicationKey", out var applicationKey) &&
                string.Equals(applicationKey, _expectedApplicationKey, StringComparison.OrdinalIgnoreCase))
            {
                // Cheia de aplicație este validă, permiteți accesul la metoda API
                await _next.Invoke(context);
            }
            else
            {
                // Cheia de aplicație este invalidă, returnați un mesaj de eroare
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("Unauthorized. Invalid Application Key.");
            }
        }
    }
}
