using Nancy;
using Nancy.Configuration;

namespace FP.DotnetnTheBox.Webhock
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        public override void Configure(INancyEnvironment environment)
        {
            environment.Tracing(enabled:false, displayErrorTraces:false);
            base.Configure(environment);
        }
    }
}
