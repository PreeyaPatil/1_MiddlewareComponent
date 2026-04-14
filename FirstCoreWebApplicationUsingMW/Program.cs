namespace FirstCoreWebApplicationUsingMW
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            //Map,MapGet,Run,Use are the builtin extensions 
            // MAp, MapGet are mainly use to create minimal API's and it is used to handle the request and response without using any middleware component, but in this example we are going to use middleware component to handle the request and response. so we are not going to use Map and MapGet extension methods in this example.
            //app.Map("/", () => "Hello World!");
            //app.MapGet("/welcome/name", (string name) => $"Welcome {name} to ASP.NET Core Web API!");
            if (app.Environment.IsDevelopment()) 
            { 
                app.UseDeveloperExceptionPage();
            }
            app.MapGet("/Division", async (context) => {
                int number1 = 10, number2 = 0;
                await context.Response.WriteAsync($"The result of {number1} divided by {number2} is: {number1/number2}");
            });

            //Configure the first middleware to handle the request and response usinf Run extension method
            //app.Use(async (context,next) =>
            //{
            //    await context.Response.WriteAsync("Hello World from USE Middleware! and it calls the next MW component.");
            //    await next();
            //});
            ////app.Run(async (context) => {
            ////    await context.Response.WriteAsync("\n\nHello World from RUN Middleware Component!,It doesn't call next MW because RUN is terminal MW component.");
            ////    //if want to execute the next MW component then we can use Use instead of Run with next() method as shown in above code snippet.
            ////});
            //app.Use(async (context,next) => {
            //    await context.Response.WriteAsync("\n\nHello World from USE Middleware Component!It calls next MW component.");
            //    await next();
            //});
            //app.Run(SecondMiddleWareComponent);

            // Starts the web application which begins listening for incoming requests
            app.Run();
        }
        public static async Task SecondMiddleWareComponent(HttpContext context)
        {
            await context.Response.WriteAsync("\n\nHello World from Second Middleware Component!");
        }
    }
    
}
