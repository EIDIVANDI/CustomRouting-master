using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomRouting.CustomRoutes
{
    public class CustomActionRoute
    {
        public string Name { get; set; }
        public List<CustomRouteBase> Routes { get; set; }

        public CustomActionRoute(string name, List<CustomRouteBase> routes)
        {
            this.Name = name;
            this.Routes = routes;
        }
    }
}