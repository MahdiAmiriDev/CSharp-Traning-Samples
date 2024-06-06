namespace LearninBasics
{
    public class MyFirstMiddleWear
    {
        private readonly RequestDelegate _next;

        public MyFirstMiddleWear(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Query.ContainsKey("baby"))
            {
                httpContext.Response.ContentType = "text/html";
                await httpContext.Response.WriteAsJsonAsync("hi baby ....");
            }

            await _next(httpContext);
        }
    }
}
