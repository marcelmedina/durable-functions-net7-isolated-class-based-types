using Microsoft.DurableTask;
using Microsoft.Extensions.Logging;

namespace DurableFunctionsNet7IsolatedClassBasedTypes;

[DurableTask(nameof(SayHelloActivity))]
public class SayHelloActivity : TaskActivity<string, string>
{
    private readonly ILogger _logger;

    public SayHelloActivity(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<SayHelloActivity>();
    }

    public override Task<string> RunAsync(TaskActivityContext context, string cityName)
    {
        _logger.LogInformation("Saying hello to {name}", cityName);

        return Task.FromResult($"Hello, {cityName}!");
    }
}
