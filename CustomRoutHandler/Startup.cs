using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomRouting.Startup))]
namespace CustomRouting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
