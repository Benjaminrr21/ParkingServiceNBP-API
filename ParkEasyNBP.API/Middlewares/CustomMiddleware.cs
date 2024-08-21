using Newtonsoft.Json;
using ParkEasyNBP.Domain.Models;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace ParkEasyNBP.API.Middlewares
{
    public class CustomMiddleware
    {
        private RequestDelegate _next;
        private readonly ILogger logger;
        private IWebHostEnvironment _env;
        private Regex _emailRegex;
        private Regex _regNumberRegex;
        private Regex _ooCardRegex;
        private Regex _sCardRegex;

        public CustomMiddleware(RequestDelegate next, ILogger<CustomMiddleware> logger, IWebHostEnvironment env)
        {
            _next = next;
            this.logger = logger;
            _env = env;
            _emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);
            _regNumberRegex = new Regex(@"^[A-Z]{2}-\d{3}-[A-Z]{2}$");
            _ooCardRegex = new Regex(@"^OC-\d{4}$");
            _sCardRegex = new Regex(@"^SC-\d{4}$");

        }
        //glavna metoda - INVOKE , kako obradjuje zahtev
        //probamo da pustimo request da prodje u sledeci middleware
        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/api/Vehicle"))
            {
                if (context.Request.Method == HttpMethods.Post)
                {
                    context.Request.EnableBuffering(); // Omogućava ponovno čitanje tela zahteva

                    var isValid = await ValidateRegNumber(context);
                    if (!isValid)
                    {
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        await context.Response.WriteAsync("NEPRAVILAN REGISTARSKI BROJ.");
                        return;
                    }
                }
            }
            if (context.Request.Path.StartsWithSegments("/api/Auth/register"))
            {
               /* if(context.Request.Method == HttpMethods.Post)
                {
                   var isValid = await ValidateEmail(context);
                    if (!isValid)
                    {
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        await context.Response.WriteAsync("NEPRAVILAN EMAIL.");
                        return;
                    }
                }*/
            }
            if (context.Request.Path.StartsWithSegments("/api/OneOffCard"))
            {
                if (context.Request.Method == HttpMethods.Post)
                {
                    context.Request.EnableBuffering(); // Omogućava ponovno čitanje tela zahteva

                    var isValid = await ValidateOCard(context);
                    if (!isValid)
                    {
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        await context.Response.WriteAsync("NEPRAVILAN UNOS JEDNOKRATNE KARTE.");
                        return;
                    }
                }
            }
            if (context.Request.Path.StartsWithSegments("/api/SubscriptionCard"))
            {
                if (context.Request.Method == HttpMethods.Post)
                {
                    context.Request.EnableBuffering(); // Omogućava ponovno čitanje tela zahteva

                    var isValid = await ValidateSCard(context);
                    if (!isValid)
                    {
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        await context.Response.WriteAsync("NEPRAVILAN UNOS PRETPLATNE KARTE.");
                        return;
                    }
                }
            }
            await _next(context);
        }
        private async Task<bool> ValidateRegNumber(HttpContext context) 
        {
            var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
            context.Request.Body.Position = 0;
            var ticket = JsonConvert.DeserializeObject<Vehicle>(body);
            logger.LogInformation("AAAAA");
            logger.LogInformation("Vehicle object: {Vehicle}", JsonConvert.SerializeObject(ticket));



            if (string.IsNullOrEmpty(ticket.RegNumber) || !_regNumberRegex.IsMatch(ticket.RegNumber))
            {
                return false;
            }
            return true;
        }
      /*  private async Task<bool> ValidateEmail(HttpContext context)
        {
            var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
            var user = JsonConvert.DeserializeObject<ApplicationUser>(body);
            logger.LogInformation("Email validacija...");


            if (string.IsNullOrEmpty(user.Email) || !_emailRegex.IsMatch(user.Email))
            {
                return false;
            }
            return true;
        }*/
        private async Task<bool> ValidateOCard(HttpContext context)
        {
            var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
            context.Request.Body.Position = 0;
            var card = JsonConvert.DeserializeObject<OneOffCard>(body);
            logger.LogInformation("OCard validacija...");


            if (string.IsNullOrEmpty(card.Code) || !_ooCardRegex.IsMatch(card.Code))
            {
                return false;
            }
            return true;
        }
        private async Task<bool> ValidateSCard(HttpContext context)
        {
            var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
            context.Request.Body.Position = 0;
            var card = JsonConvert.DeserializeObject<SubscriptionCard>(body);
            logger.LogInformation("SCard validacija...");


            if (string.IsNullOrEmpty(card.Code) || !_sCardRegex.IsMatch(card.Code))
            {
                return false;
            }
            return true;
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
