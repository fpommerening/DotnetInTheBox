using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace FP.DotnetnTheBox.Webhock
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
               .UseContentRoot(Directory.GetCurrentDirectory())
               .UseKestrel()
               .UseStartup<Startup>()
               .UseUrls("http://0.0.0.0:4000")
               .Build();

            host.Run();
        }
    }
}
