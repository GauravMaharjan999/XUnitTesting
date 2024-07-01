
Console.WriteLine("");
// ILogger.cs
public interface ILogger
{
    void Log(string message);
}

// CalculatorService.cs
public class CalculatorService
{
    private readonly ILogger _logger;

    public CalculatorService(ILogger logger)
    {
        _logger = logger;
    }

    public int Add(int a, int b)
    {
        int result = a + b;
        _logger.Log($"Add: {a} + {b} = {result}");
        return result;
    }

    public int Subtract(int a, int b)
    {
        int result = a - b;
        _logger.Log($"Subtract: {a} - {b} = {result}");
        return result;
    }
}
