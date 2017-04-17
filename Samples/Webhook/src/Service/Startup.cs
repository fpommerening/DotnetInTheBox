using Microsoft.AspNetCore.Builder;
using Nancy.Owin;

namespace FP.DotnetnTheBox.Webhock
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseOwin(x => x.UseNancy());
        }
    }
}
