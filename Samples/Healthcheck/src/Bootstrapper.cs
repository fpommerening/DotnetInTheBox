using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

namespace FP.DotnetInTheBox.Healthcheck
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            var dataRepo = new DataRepo();
            container.Register(dataRepo);

            base.ApplicationStartup(container, pipelines);
        }

        public override void Configure(Nancy.Configuration.INancyEnvironment environment)
        {
            environment.Tracing(enabled: false, displayErrorTraces: true);
        }
    }
}
