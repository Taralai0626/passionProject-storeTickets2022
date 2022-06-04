using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(passionProject_storeTickets2022.Startup))]
namespace passionProject_storeTickets2022
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
