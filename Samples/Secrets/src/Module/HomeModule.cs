using System;
using System.Text;

namespace FP.DotnetInTheBox.Secrets.Module
{
    public class HomeModule : Nancy.NancyModule
    {
        public HomeModule()
        {
            Get("/", _ =>
            {
                var sb = new StringBuilder();
                sb.AppendLine($"Secret-Sample {DateTime.Now:G}");
                var databaseconfig = SecretHelper.GetSecret("databaseconfig.cfg");
                if (string.IsNullOrEmpty(databaseconfig))
                {
                    sb.AppendLine("Es wurde keine databaseconfig gefunden");
                }
                else
                {
                    sb.AppendLine($"databaseconfig:{databaseconfig}");
                }
                return sb.ToString();
            });
        }
    }
}
