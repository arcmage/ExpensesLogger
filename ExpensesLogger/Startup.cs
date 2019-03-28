using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExpensesLogger.Startup))]
namespace ExpensesLogger
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
