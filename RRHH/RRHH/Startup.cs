using Hangfire;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RRHH.Startup))]
[assembly: log4net.Config.XmlConfigurator(ConfigFile ="web.config", Watch = true)]
namespace RRHH
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration
               .UseSqlServerStorage("TimeSheetConnection");

            //app.UseHangfireDashboard("/jobslist");
            app.UseHangfireServer();

            ConfigureAuth(app);
        }
    }
}
