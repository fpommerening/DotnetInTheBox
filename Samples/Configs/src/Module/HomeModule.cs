using System;
using Microsoft.Extensions.Configuration;

namespace FP.DotnetInTheBox.Configs.Module
{
    public class HomeModule : Nancy.NancyModule
    {
        public HomeModule(IConfiguration cfg)
        {
            Get("/", _ => $" Config-Sample {DateTime.Now:G} \n {cfg["greeting"]}");
        }
    }
}
