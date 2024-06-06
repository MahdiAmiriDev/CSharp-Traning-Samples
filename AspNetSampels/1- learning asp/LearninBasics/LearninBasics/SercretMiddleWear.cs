namespace LearninBasics
{
    public class SercretMiddleWear
    {
        private readonly RequestDelegate next;

        public SercretMiddleWear(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.ContentType = "text/html";
            await httpContext.Response.WriteAsJsonAsync("this is a secret middleWear");
            await next(httpContext);
        }
    }
}
