﻿using System;

namespace FP.DotnetInTheBox.BuildOutside.Modules
{
    public class HomeModule : Nancy.NancyModule
    {
        public HomeModule()
        {
            Get("/", args => $"Hallo Spartakiade - {DateTime.Now}");
        }
    }
}
