namespace LearninBasics
{
    public static  class HostingExtension
    {
        public static WebApplication ConfigureSrevices(this WebApplicationBuilder builder)
        {
            
            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.MapGet("/", () => "hello world");

            app.Use(async (httpContext, next) =>
            {
                if (httpContext.Request.Query.ContainsKey("Show"))
                {
                    httpContext.Response.ContentType = "text/html";
                    await httpContext.Response.WriteAsJsonAsync("hello from first middleWear");
                }
                await next();
            });


            return app;
        }
         

    }
}
