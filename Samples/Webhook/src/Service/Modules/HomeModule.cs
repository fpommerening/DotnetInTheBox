using System;

namespace FP.Spartakiade2017.Docker.WebHook.Service.Modules
{
    public class HomeModule : Nancy.NancyModule
    {
        public HomeModule()
        {
            Get("/", args => $"Docker Hub Webhock {DateTime.Now.Ticks}");
        }
    }
}
