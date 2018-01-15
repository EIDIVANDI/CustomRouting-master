using CustomRouting.CustomRoutes;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Routing;

namespace CustomRouting
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            var cultureEN = CultureInfo.GetCultureInfo("en-US");
            var cultureFR = CultureInfo.GetCultureInfo("fr-FR");

            var CustomRouteTables = new List<CustomControllerRoute>{
            new CustomControllerRoute("Home"
                    , new List<CustomRouteBase>{
                                new CustomRouteBase(cultureEN, "Home")
                            ,new CustomRouteBase(cultureFR, "Demarrer")
                    }
                ,new List<CustomActionRoute>{
                        new CustomActionRoute("About"
                        , new List<CustomRouteBase>{
                                new CustomRouteBase(cultureEN, "About")
                            ,new CustomRouteBase(cultureFR, "Infos")
                        })
                        , new CustomActionRoute("Home"
                        , new List<CustomRouteBase>{
                                new CustomRouteBase(cultureEN, "Home")
                            ,new CustomRouteBase(cultureFR, "Demarrer")
                        })
                    , new CustomActionRoute("Contact"
                        , new List<CustomRouteBase>{
                                new CustomRouteBase(cultureEN, "Contact")
                            ,new CustomRouteBase(cultureFR, "InformationSurLaPersonne")
                        })
                })
            ,new CustomControllerRoute("Account"
                    ,
                    new List<CustomRouteBase>{
                                new CustomRouteBase(cultureEN, "Account")
                            ,new CustomRouteBase(cultureFR, "Compte")
                    }
                    ,
                    new List<CustomActionRoute>
                    {
                        new CustomActionRoute("Login"
                        , new List<CustomRouteBase>{
                                new CustomRouteBase(cultureEN, "Login")
                            ,new CustomRouteBase(cultureFR, "Authentification")
                        })
                        ,
                        new CustomActionRoute("Register"
                        , new List<CustomRouteBase>{
                                new CustomRouteBase(cultureEN, "Register")
                            ,new CustomRouteBase(cultureFR, "Enregistrement")
                        })

                    }
            )
        };

            routes.Add("LocalizedRoute", new CustomRoute(
                "{controller}/{action}/{id}",
                new RouteValueDictionary(new { controller = "Home", action = "Index", id = string.Empty }),
                CustomRouteTables,
                new MvcRouteHandler()));

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
