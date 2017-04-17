using System;
using System.Threading;

namespace FP.DotnetInTheBox.RaspberryPi
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var host = new NancyHost(new Uri("http://localhost:7777")))
                {
                    host.Start();
                    Console.WriteLine("Starting WebApp on Url http://localhost:7777");
                    while (Console.ReadLine() != "quit") { Thread.Sleep(Int32.MaxValue); }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}
