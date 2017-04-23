#addin nuget:?package=SharpZipLib&version=0.86.0
#addin nuget:?package=Cake.Compression&version=0.1.1
#addin "Cake.Docker"


var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

var publishDir = Directory("../../tmp/webapp/");
var dockerDir = Directory("./dockerfiles/webapp/");


Task("Clean")
    .Does(() =>
{
    CleanDirectory(publishDir);
});

Task("Restore")
.IsDependentOn("Clean")
  .Does(() =>
{
    DotNetCoreRestore("./src/WebApp/");
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
       DotNetCoreBuild("./src/WebApp/", settings);
  
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

     DotNetCorePublish("./src/WebApp/", settings);

});

Task("Compression")
    .IsDependentOn("Publish")
  .Does(() =>
{
    GZipCompress(publishDir, dockerDir + Directory("app") + File( "webapp.tar.gz"), 9);
});

Task("DockerBuild")
    .IsDependentOn("Compression")
  .Does(() =>
{
    var settings = new DockerBuildSettings
     {
         File = dockerDir + File("Dockerfile.local"),
         Tag = new [] {"fpommerening/dotnetinthebox:buildoutside"}
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