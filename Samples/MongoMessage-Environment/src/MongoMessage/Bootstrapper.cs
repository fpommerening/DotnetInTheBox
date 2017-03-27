using FP.DotnetInTheBox.Environment.Data;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

namespace FP.DotnetInTheBox.Environment
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            container.Register(new MessageRepository(EnvironmentVariable.GetValueOrDefault("MessageConnectionString", "mongodb://localhost")));
            base.ApplicationStartup(container, pipelines);
        }
    }
}
