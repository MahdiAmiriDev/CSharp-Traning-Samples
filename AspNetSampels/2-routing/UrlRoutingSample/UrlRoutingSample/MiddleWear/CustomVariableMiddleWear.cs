namespace UrlRoutingSample.MiddleWear
{
    public class CustomVariableMiddleWear
    {
        public async Task InvokeAsync(HttpContext httpContext)
        {
            string mavadeLazem = string.Empty;

            var value = httpContext.Request.RouteValues["Name"];

            switch (value)
            {
                case "Nimroo":
                    mavadeLazem = "roghan+namak +tokhme morgh";
                    break;
                case "Omlet":
                    mavadeLazem = "roghan +namak tokhme +morgh goje";
                    break;
                case "NoonPanir":
                    mavadeLazem = "noon + panir";
                    break;
                case "Kotlet":
                    httpContext.Response.Redirect("/mv/Nimroo");
                    return;
            }

            if (!string.IsNullOrEmpty(mavadeLazem))
            {
                httpContext.Response.ContentType = "text/html";
                httpContext.Response.StatusCode = 200;
                await httpContext.Response.WriteAsync(mavadeLazem);
            }
        }
    }
}
