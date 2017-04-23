#addin nuget:?package=SharpZipLib&version=0.86.0
#addin nuget:?package=Cake.Compression&version=0.1.1
#addin "Cake.Docker"


var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

var publishDir = Directory("../../tmp/webhock/");
var dockerDir = Directory("./dockerfiles/service/");


Task("Clean")
    .Does(() =>
{
    CleanDirectory(publishDir);
});

Task("Restore")
.IsDependentOn("Clean")
  .Does(() =>
{
    DotNetCoreRestore("./src/Service/");
});

Task("Build")
    .IsDependentOn("Restore")
  .Does(() =>
{
   var settings = new DotNetCoreBuildSettings
     {
         Framework = "netcoreapp1.0",
         Configuration = configuration,
         OutputDirectory = "./artifacts/"
     };
       DotNetCoreBuild("./src/Service/", settings);
  
});

Task("Publish")
    .IsDependentOn("Build")
  .Does(() =>
{
      var settings = new DotNetCorePublishSettings
     {
         Framework = "netcoreapp1.0",
         Configuration = configuration,
         OutputDirectory = publishDir
     };

     DotNetCorePublish("./src/Service/", settings);

});

Task("Compression")
    .IsDependentOn("Publish")
  .Does(() =>
{
    CreateDirectory(dockerDir + Directory("app"));

    GZipCompress(publishDir, dockerDir + Directory("app") + File( "webhook.tar.gz"), 9);
});

Task("DockerBuild")
    .IsDependentOn("Compression")
  .Does(() =>
{
    var settings = new DockerBuildSettings
     {
         File = dockerDir + File("Dockerfile"),
         Tag = new [] {"fpommerening/dotnetinthebox:webhook"}
     };
    DockerBuild(settings, dockerDir);
});


//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("DockerBuild");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);