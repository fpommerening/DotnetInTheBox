var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

var publishDir = Directory("./tmp/webapp");


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









//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Publish");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);