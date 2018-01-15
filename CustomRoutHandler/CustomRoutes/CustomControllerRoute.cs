using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomRouting.CustomRoutes
{
    public class CustomControllerRoute
    {
        public string Name { get; set; }
        public List<CustomRouteBase> CustomRoute { get; set; }
        public List<CustomActionRoute> CustomActionRoutes { get; set; }

        public CustomControllerRoute(string name, List<CustomRouteBase> CustomRoute, List<CustomActionRoute> actionsList)
        {
            this.Name = name;
            this.CustomRoute = CustomRoute;
            this.CustomActionRoutes = actionsList;
        }
    }
}