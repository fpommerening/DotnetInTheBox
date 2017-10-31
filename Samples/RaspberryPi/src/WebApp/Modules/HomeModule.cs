using System;

namespace FP.DotnetInTheBox.RaspberryPi.Modules
{
    public class HomeModule : Nancy.NancyModule
    {
        public HomeModule()
        {
            Get("/", args => $".net in a box (on arm) \n# {DateTime.Now} \n#  {System.Net.Dns.GetHostName()}");
        }
    }
}
