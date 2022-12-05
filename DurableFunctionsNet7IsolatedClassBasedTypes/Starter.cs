using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace DurableFunctionsNet7IsolatedClassBasedTypes;

public class Starter
{
    private readonly ILogger _logger;

    public Starter(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<Starter>();
    }

    [Function(nameof(StarterAsync))]
    public async Task<HttpResponseData> StarterAsync(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
        [DurableClient] DurableClientContext durableContext)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        string instanceId = await durableContext.Client.ScheduleNewOrchestrationInstanceAsync(nameof(SayHelloOrchestrator));

        _logger.LogInformation("Created new orchestration with instance ID = {instanceId}", instanceId);

        return durableContext.CreateCheckStatusResponse(req, instanceId);
    }
}
