using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace CustomRouting.CustomRoutes
{
    public class CustomRouteBase
    {
        public CultureInfo CultureInfo { get; set; }
        public string Value { get; set; }
        public CustomRouteBase(CultureInfo culture, string value)
        {
            CultureInfo = culture;
            Value = value;
        }
    }
}