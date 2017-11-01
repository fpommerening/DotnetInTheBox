using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Docker.DotNet;
using Docker.DotNet.Models;

namespace FP.DotnetInTheBox.ClientApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var endpointUri = new Uri(EnvironmentVariable.GetValueOrDefault("EndpointUri", "http://localhost:2375"));
                var client = new DockerClientConfiguration(endpointUri).CreateClient();

                //ListImages(client).Wait();
                //client.Images.SearchImagesAsync(new ImagesSearchParameters {})
                //PullImage(client).Wait();
               // StartContainer(client).Wait();
              //  StopContainer(client).Wait();



                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.ReadLine();
        }

       


        private static async Task ListImages(DockerClient client)
        {
            var param = new ImagesListParameters();
            // auch Zwischenebenen zeigen
            //param.All = true;
            // Filtern per Name
            //param.MatchName = "ubuntu";
            

            foreach (var img in client.Images.ListImagesAsync(param).Result)
            {
                Console.WriteLine($"{img.ID} - {img.RepoTags?.FirstOrDefault()}");
            }
        }

        private static async Task PullImage(DockerClient client)
        {
            Stream stream = await client.Images.PullImageAsync(new ImagesPullParameters
            {
                Parent = "rabbitmq",
                Tag = "latest"
            }, null);


            using (var sr = new StreamReader(stream))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

        private static async Task StartContainer(DockerClient client)
        {
            var createParam = new CreateContainerParameters
            {
                Image = "fpommerening/dotnetinthebox:pingtest",
                Cmd = new List<string> {"ping", "8.8.8.8"},
                Name = "pingtest"
            };

            var result =  await client.Containers.CreateContainerAsync(createParam);
            var id = result.ID;
            Console.WriteLine($"ID {id}");
            await client.Containers.StartContainerAsync(id, null);
        }

        private static async Task StopContainer(DockerClient client)
        {
            var listParam = new ContainersListParameters
            {
                Filters = new Dictionary<string, IDictionary<string, bool>>
                {
                    {"name", new Dictionary<string, bool> {{"pingtest", true}}}
                }
            };

            var result = await client.Containers.ListContainersAsync(listParam);

            if (result.Any())
            {
                await client.Containers.StopContainerAsync(result.First().ID, new ContainerStopParameters(),
                    CancellationToken.None);
            }

        }
    }
}
