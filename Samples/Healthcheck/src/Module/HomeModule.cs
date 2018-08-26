namespace FP.DotnetInTheBox.Healthcheck.Module
{
    public class HomeModule : Nancy.NancyModule
    {
        public HomeModule(DataRepo dataRepo)
        {
            Get("/", _ => $"The Application is {(dataRepo.IsHealthy ? "healthy" : "sick")} - last update {dataRepo.LastChangeUtc:G} ");

            Post("/healthy", _ =>
            {
                dataRepo.IsHealthy = true;
                return Nancy.HttpStatusCode.Accepted;
            });

            Post("/sick", _ =>
            {
                dataRepo.IsHealthy = false;
                return Nancy.HttpStatusCode.Accepted;
            });
        }
    }
}
