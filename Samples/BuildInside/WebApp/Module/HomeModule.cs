using System;

namespace FP.DotnetInTheBox.BuildInside.Module
{
    public class HomeModule : Nancy.NancyModule
    {
        public HomeModule()
        {
            Get("/", args => $"Hallo Usergroup - {DateTime.Now}");
        }
    }
}
