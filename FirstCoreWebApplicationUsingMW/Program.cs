namespace FirstCoreWebApplicationUsingMW
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            //MapGet,Run,Use are the builtin extensions 

            //app.MapGet("/", () => "Hello World!");
            //app.MapGet("/welcome/name", (string name) => $"Welcome {name} to ASP.NET Core Web API!");

            //Configure the first middleware to handle the request and response usinf Run extension method
            app.Use(async (context,next) =>
            {
                await context.Response.WriteAsync("Hello World from USE Middleware! and it calls the next MW component.");
                await next();
            });
            //app.Run(async (context) => {
            //    await context.Response.WriteAsync("\n\nHello World from RUN Middleware Component!,It doesn't call next MW because RUN is terminal MW component.");
            //    //if want to execute the next MW component then we can use Use instead of Run with next() method as shown in above code snippet.
            //});
            app.Use(async (context,next) => {
                await context.Response.WriteAsync("\n\nHello World from USE Middleware Component!It calls next MW component.");
                await next();
            });
            app.Run(SecondMiddleWareComponent);

            // Starts the web application which begins listening for incoming requests
            app.Run();
        }
        public static async Task SecondMiddleWareComponent(HttpContext context)
        {
            await context.Response.WriteAsync("\n\nHello World from Second Middleware Component!");
        }
    }
    
}
