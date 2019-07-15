using System;
using Microsoft.AspNetCore.Mvc;

namespace FP.DotnetInTheBox.BuildMultistage.Controller
{

    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        [Route("/")]
        public string Index()
        {
            return $"Hallo Meetup {DateTime.UtcNow:G}";
        }
    }
}
