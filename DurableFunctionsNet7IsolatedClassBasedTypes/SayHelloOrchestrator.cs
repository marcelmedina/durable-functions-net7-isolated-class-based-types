using Microsoft.DurableTask;

namespace DurableFunctionsNet7IsolatedClassBasedTypes;

[DurableTask(nameof(SayHelloOrchestrator))]
public class SayHelloOrchestrator : TaskOrchestrator<string?, string>
{
    public override async Task<string> RunAsync(TaskOrchestrationContext context, string? input)
    {
        string result = "";
        result += await context.CallSayHelloActivityAsync("Auckland") + " ";
        result += await context.CallSayHelloActivityAsync("London") + " ";
        result += await context.CallSayHelloActivityAsync("Seattle");
        return result;
    }
}
