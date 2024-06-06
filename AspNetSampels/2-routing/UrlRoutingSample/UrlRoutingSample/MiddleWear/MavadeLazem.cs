namespace UrlRoutingSample.MiddleWear
{
    public class MavadeLazem
    {
        private readonly RequestDelegate _next;

        public MavadeLazem(RequestDelegate next)
        {
            _next = next;
        }

        public MavadeLazem()
        {

        }

        public async Task Invoke(HttpContext httpContext)
        {
            //www.eee.com/mv/Nimroo
            //www.eee.com/mv/Omlet
            //www.eee.com/mv/NoonPanir                       
            var path = httpContext.Request.Path.ToString();
            var pathSegment = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
            string mavadeLazem = string.Empty;
            if (pathSegment.Length == 2 && pathSegment[0] == "mv")
            {
                switch (pathSegment[1])
                {
                    case "Nimroo":
                        mavadeLazem = "roghan namak tokhme morgh";
                        break;
                    case "Omlet":
                        mavadeLazem = "roghan namak tokhme morgh goje";
                        break;
                    case "NoonPanir":
                        mavadeLazem = "noon panir";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(mavadeLazem))
            {
                httpContext.Response.ContentType = "text/html";
                httpContext.Response.StatusCode = 200;
                await httpContext.Response.WriteAsync(mavadeLazem);
            }

            if(_next != null)
            await _next(httpContext);
        }
    }

    public class TarzeTahieh
    {
        private readonly RequestDelegate _next;

        public TarzeTahieh(RequestDelegate next)
        {
            _next = next;
        }

        public TarzeTahieh()
        {

        }

        public async Task Invoke(HttpContext httpContext)
        {
            //www.eee.com/mv/Nimroo
            //www.eee.com/mv/Omlet
            //www.eee.com/mv/NoonPanir                       
            var path = httpContext.Request.Path.ToString();
            var pathSegment = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
            string mavadeLazem = string.Empty;
            if (pathSegment.Length == 2 && pathSegment[0] == "tt")
            {
                switch (pathSegment[1])
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
            }
            if (!string.IsNullOrEmpty(mavadeLazem))
            {
                httpContext.Response.ContentType = "text/html";
                httpContext.Response.StatusCode = 200;
                await httpContext.Response.WriteAsync(mavadeLazem);
            }

            if (_next != null)
                await _next(httpContext);
            
        }
    }
}

