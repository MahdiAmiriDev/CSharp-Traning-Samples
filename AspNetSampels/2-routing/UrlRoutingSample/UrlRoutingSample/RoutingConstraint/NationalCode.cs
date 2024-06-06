namespace UrlRoutingSample.RoutingConstraint
{
    public class NationalCode : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var value = values[routeKey].ToString();

            if(value.Length != 0 && value.Length ==10)
                return true;
            return false;
        }
    }
}
