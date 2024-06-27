namespace ParkEasyNBP.API.Middlewares
{
    public class MyMiddleware
    {
        private readonly ILogger logger;
        private readonly RequestDelegate next;

        public MyMiddleware(ILogger<MyMiddleware> logger, RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var start = DateTime.UtcNow;
            await next.Invoke(context);
            logger.LogInformation($"Request: {context.Request.Path}: {(DateTime.UtcNow - start).TotalMilliseconds}ms");

        }
    }

    public static class MyExtension
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyMiddleware>();
        }
    }
}
