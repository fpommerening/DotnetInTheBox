using System;

namespace FP.DotnetnTheBox.Webhock.Modules
{
    public class HomeModule : Nancy.NancyModule
    {
        public HomeModule()
        {
            Get("/", args => $"Docker Hub Webhock {DateTime.Now.Ticks}");
        }
    }
}
