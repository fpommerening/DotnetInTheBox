using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Docker.DotNet;
using Docker.DotNet.Models;


namespace FP.DotnetnTheBox.Webhock.Controller
{
    public class ContainerHelper : IDisposable
    {
        private readonly DockerClient _client;

        public ContainerHelper(string endpointUrl)
        {
            _client = new DockerClientConfiguration(new Uri(endpointUrl)).CreateClient();
        }

        public async Task PullImage(string owner, string name, string tag, CancellationToken ct)
        {
            var pullParams = new ImagesCreateParameters
            {
                Repo = string.IsNullOrEmpty(owner) ? name : $"{owner}/{name}",
                Tag = tag
            };

            await _client.Images.CreateImageAsync(pullParams, null, null,ct);
        }

        public async Task StopContainer(string id, CancellationToken ct)
        {
            await _client.Containers.StopContainerAsync(id, new ContainerStopParameters(), ct);
        }

        public Task DeleteContainer(string containerId)
        {
            return _client.Containers.RemoveContainerAsync(containerId, new ContainerRemoveParameters());
        }

        public async Task<string> StartContainer(string containerName, string owner, string name, string tag, string portMap, CancellationToken ct)
        {
            var createParam = new CreateContainerParameters();
            if (string.IsNullOrEmpty(owner))
            {
                createParam.Image = $"{name}:{tag}";
            }
            else
            {
                createParam.Image = $"{owner}/{name}:{tag}";
            }
            createParam.Name = containerName;

            if (!string.IsNullOrEmpty(portMap))
            {
                var containerPort = portMap.Split('#').First();
                var hostPort = portMap.Split('#').Last();

                createParam.ExposedPorts = new Dictionary<string, EmptyStruct>
                {
                    {
                        containerPort, new EmptyStruct()
                    }
                };
                 
                createParam.HostConfig = new HostConfig
                {
                    PortBindings = new Dictionary<string, IList<PortBinding>>
                    {
                        {
                            containerPort, new List<PortBinding>{ new PortBinding { HostPort = hostPort } }
                        }
                    }
                };
            }

            var result = await _client.Containers.CreateContainerAsync(createParam,ct);
            if (result.Warnings != null && result.Warnings.Any())
            {
                throw new Exception($"Warning by creating container {containerName} {string.Join("\n", result.Warnings)}");
            }

            await _client.Containers.StartContainerAsync(result.ID, null, ct);
            return result.ID;
        }

        public async Task<string> GetContainerIdByName(string name, CancellationToken ct)
        {
            var listParam = new ContainersListParameters
            {
                Filters = new Dictionary<string, IDictionary<string, bool>>
                {
                    {"name", new Dictionary<string, bool> {{ name, true}}}
                },
                All = true
            };

            var result = await _client.Containers.ListContainersAsync(listParam, ct);
            if (!result.Any())
            {
                return string.Empty;
            }
            else
            {
                return result.First().ID;
            }
        }

       

        public void Dispose()
        {
            _client?.Dispose();
        }


       
    }
}
