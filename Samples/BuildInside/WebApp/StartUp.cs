using Microsoft.AspNetCore.Builder;
using Nancy.Owin;

namespace FP.DotnetInTheBox.BuildInside
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseOwin(x => x.UseNancy());
        }
    }
}
