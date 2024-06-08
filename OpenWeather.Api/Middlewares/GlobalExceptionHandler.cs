using Microsoft.AspNetCore.Diagnostics;
using OpenWeather.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace OpenWeather.Api.Middlewares
{
    public static class GlobalExceptionHandler
    {
        public static async Task Handle(HttpContext httpContext)
        {
            var exceptionHandlerFeature = httpContext.Features.Get<IExceptionHandlerFeature>();

            if (exceptionHandlerFeature is null)
                return;

            var (httpStatusCode, message) = exceptionHandlerFeature.Error switch
            {
                OpenWeatherException ex => (HttpStatusCode.BadRequest, ex.Message),
                _ => (HttpStatusCode.InternalServerError, "Erro inesperado.")
            };

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)httpStatusCode;

            var jsonResponse = new
            {
                httpContext.Response.StatusCode,
                Message = message,
            };

            var jsonSerialized = JsonSerializer.Serialize(jsonResponse);
            await httpContext.Response.WriteAsync(jsonSerialized);
        }
    }
}
