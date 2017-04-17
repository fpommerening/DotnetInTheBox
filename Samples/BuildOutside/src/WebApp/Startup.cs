using Microsoft.AspNetCore.Builder;
using Nancy.Owin;

namespace FP.DotnetInTheBox.BuildOutside
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseOwin(x => x.UseNancy());
        }
    }
}
