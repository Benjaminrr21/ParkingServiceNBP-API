using Newtonsoft.Json;
using ParkEasyNBP.Domain.Models;
using System.Net;
using System.Text.Json;

namespace ParkEasyNBP.API.Middlewares
{
    public class CustomMiddleware
    {
        private RequestDelegate _next;
        private readonly ILogger logger;
        private IWebHostEnvironment _env;
        public CustomMiddleware(RequestDelegate next, ILogger<CustomMiddleware> logger, IWebHostEnvironment env)
        {
            _next = next;
            this.logger = logger;
            _env = env;
        }
        //glavna metoda - INVOKE , kako obradjuje zahtev
        //probamo da pustimo request da prodje u sledeci middleware
        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/api/Vehicles"))
            {
                if (context.Request.Method == HttpMethods.Post)
                {
                    context.Request.EnableBuffering(); // Omogućava ponovno čitanje tela zahteva

                    var isValid = await ValidateTicket(context);
                    if (!isValid)
                    {
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        await context.Response.WriteAsync("NEPRAVILAN UNOS.");
                        return;
                    }
                }
            }
            /* try
             {
                 await _next(context);
             }
             catch (Exception ex)
             {
                 HandleException(ex, context);
             }*/
            await _next(context);
        }
        private async Task<bool> ValidateTicket(HttpContext context) 
        {
            var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
            context.Request.Body.Position = 0;
            var ticket = JsonConvert.DeserializeObject<Vehicle>(body);
            logger.LogInformation("AAAAA");
            logger.LogInformation("Vehicle object: {Vehicle}", JsonConvert.SerializeObject(ticket));



            if (string.IsNullOrEmpty(ticket.RegNumber))
            {
                return false;
            }
            return true;
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
            logger.LogError(e, errorMessage);
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
