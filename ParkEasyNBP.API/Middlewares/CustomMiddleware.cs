using System.Net;
using System.Text.Json;

namespace ParkEasyNBP.API.Middlewares
{
    public class CustomMiddleware
    {
        private RequestDelegate _next;
        private ILogger<CustomMiddleware> _logger;
        private IWebHostEnvironment _env;
        public CustomMiddleware(RequestDelegate next, ILogger<CustomMiddleware> logger, IWebHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }
        //glavna metoda - INVOKE , kako obradjuje zahtev
        //probamo da pustimo request da prodje u sledeci middleware
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                HandleException(ex, context);
            }
        }

        private void HandleException(Exception ex, HttpContext context)
        {
            context.Response.ContentType = "application/json";
            string errorMessage = (_env.IsDevelopment())/*!!!!!! bitno */ ? ex.Message : "Internal server error.";
            switch (ex)
            {
                /*case CourseEnrolmentException e:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    SerializaError(context, e, errorMessage);
                    break;
                case EntityNullCustomExeption ee:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    SerializaError(context, ee, errorMessage);
                    break;
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    SerializaError(context, ex, errorMessage);
                    break;*/
            }
        }

        private void SerializaError(HttpContext context, Exception e, string errorMessage)
        {
            /*Result<string> result = new Result<string>
            {
                IsSuccess = false,
                Errors = new List<string> { errorMessage }

            };*/
            _logger.LogError(e, errorMessage);
           // var json = JsonSerializer.Serialize(result);

            //context.Response.WriteAsync(json);


        }
    }
    //extension metoda za registraciju middleware-a
    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}
