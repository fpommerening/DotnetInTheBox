namespace FP.DotnetInTheBox.Healthcheck.Module
{
    public class HealthModule : Nancy.NancyModule
    {
        public HealthModule(DataRepo dataRepo)
        {
            Get("/api/healthcheck", _ =>
            {
                if (dataRepo.IsHealthy)
                {
                    return Nancy.HttpStatusCode.OK;
                }
                else
                {
                    return Nancy.HttpStatusCode.InternalServerError;
                }
            });
        }
    }
}
