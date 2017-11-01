using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace FP.DotnetInTheBox.BuildMultistage
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

          public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
