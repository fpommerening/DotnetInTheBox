using System;
using System.Threading;
using System.Threading.Tasks;
using FP.DotnetnTheBox.Webhock.Business;
using FP.DotnetnTheBox.Webhock.Model;
using Microsoft.AspNetCore.Mvc;

namespace FP.DotnetnTheBox.Webhock.Controller
{
    public class DockerHubController : ControllerBase
    {
        [HttpGet]
        [Route("/")]
        public string Index()
        {
            return $"Docker Hub Webhock {DateTime.Now.Ticks}";
        }

        [HttpPost]
        [Route("/dockerhub/{appkey}")]
        public async Task<ActionResult> Execute([FromRoute]string appkey, [FromBody] DockerhubWebhock  webhock, CancellationToken ct)
        {
            if (!string.IsNullOrEmpty(SecretHelper.GetSecret("appkey")))
            {
                if (!string.Equals(appkey, SecretHelper.GetSecret("appkey"), StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine($"HTTP 401: appkey invalid {appkey} ");
                    return Unauthorized();
                }
            }
            else
            {
                if (!string.Equals(appkey, EnvironmentVariable.GetValueOrDefault("appkey", "topsecret"), StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine($"HTTP 401: appkey invalid {appkey} ");
                    return Unauthorized();
                }
            }

            if (!string.Equals(webhock.PushData.Tag, EnvironmentVariable.GetValue("tag")) ||
                !string.Equals(webhock.Repository.Owner, EnvironmentVariable.GetValue("owner")) ||
                !string.Equals(webhock.Repository.Name, EnvironmentVariable.GetValue("imagename")))
            {
                return BadRequest( $"docker invalid: tag {webhock.PushData.Tag} / owner {webhock.Repository.Owner}  / imagename {webhock.Repository.Name}");
            }

            string containerName = EnvironmentVariable.GetValue("containername");
            string portMap = EnvironmentVariable.GetValueOrDefault("portmap", "");

            var helper = new ContainerHelper(EnvironmentVariable.GetValueOrDefault("endpointUrl", "unix:///var/run/docker.sock"));
            helper.PullImage(webhock.Repository.Owner, webhock.Repository.Name, webhock.PushData.Tag, ct);
            var containerId = await helper.GetContainerIdByName(containerName, ct);
            if (!string.IsNullOrEmpty(containerId))
            {
                await helper.StopContainer(containerId, ct);
                await helper.DeleteContainer(containerId);
            }
            await helper.StartContainer(containerName, webhock.Repository.Owner, webhock.Repository.Name, webhock.PushData.Tag, portMap, ct);
            return Ok();

        }

    }
}
