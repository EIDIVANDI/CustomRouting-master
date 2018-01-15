using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace CustomRouting.CustomRoutes
{
    public class CustomRoute : Route
    {

        public List<CustomControllerRoute> Controllers { get; private set; }

        public CustomRoute(string url, RouteValueDictionary defaults, List<CustomControllerRoute> controllers, IRouteHandler routeHandler)
            : base(url, defaults, routeHandler)
        {
            this.Controllers = controllers;
        }

        public CustomRoute(string url, RouteValueDictionary defaults, List<CustomControllerRoute> controllers, RouteValueDictionary constraints, IRouteHandler routeHandler)
            : base(url, defaults, constraints, routeHandler)
        {
            this.Controllers = controllers;
        }

        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            RouteData routeData = base.GetRouteData(httpContext);
            if (routeData == null) return null;

            string controllerFromUrl = routeData.Values["controller"].ToString();
            string actionFromUrl = routeData.Values["action"].ToString();
            var CustomControllerRoute = this.Controllers.FirstOrDefault(d => d.CustomRoute.Any(rf => rf.Value == controllerFromUrl));
            var controllerCulture = this.Controllers.SelectMany(d => d.CustomRoute).FirstOrDefault(f => f.Value == controllerFromUrl).CultureInfo;
            if (CustomControllerRoute != null)
            {
                routeData.Values["controller"] = CustomControllerRoute.Name;
                var actionCustomRoute = CustomControllerRoute.CustomActionRoutes.FirstOrDefault(d => d.Routes.Any(rf => rf.Value == actionFromUrl));
                if (actionCustomRoute != null)
                {

                    routeData.Values["action"] = actionCustomRoute.Name;

                }
                System.Threading.Thread.CurrentThread.CurrentCulture = controllerCulture;
                System.Threading.Thread.CurrentThread.CurrentUICulture = controllerCulture;
            }


            return routeData;
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {

            var requestedController = values["controller"];
            var requestedAction = values["action"];

            var CustomControllerRoute = this.Controllers.FirstOrDefault(d => d.CustomRoute.Any(rf => rf.Value == requestedController as string));
            var CustomActionRoute = CustomControllerRoute.CustomActionRoutes.FirstOrDefault(d => d.Routes.Any(rf => rf.Value == requestedAction as string));

            var controllerTranslatedName = CustomControllerRoute.CustomRoute.FirstOrDefault(d => d.CultureInfo ==  System.Threading.Thread.CurrentThread.CurrentCulture).Value;
            if (controllerTranslatedName != null)
                values["controller"] = controllerTranslatedName;

            var actionTranslate = CustomControllerRoute.CustomActionRoutes.FirstOrDefault(d => d.Routes.Any(rf => rf.Value == requestedAction as string));
            if (actionTranslate != null)
            {
                var actionTranslateName = actionTranslate.Routes.FirstOrDefault(d => d.CultureInfo == System.Threading.Thread.CurrentThread.CurrentCulture).Value;
                if (actionTranslateName != null)
                    values["action"] = actionTranslateName;
            }

            return base.GetVirtualPath(requestContext, values);
        }
    }
}
