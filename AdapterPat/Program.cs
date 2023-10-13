using System;
namespace AdapterPat
{
    public class Program
    {
        public static void Main()
        {
            Log4NetAdapter log4NetAdapter = new Log4NetAdapter();
            EdLogger edLogger = new EdLogger();
            ProductManager productManager = new ProductManager(edLogger);
            productManager.Save();
            Console.ReadLine();
        }
    }
}
public class ProductManager
{
    private ILogger _iLogger;
    public ProductManager(ILogger logger)
    {
        _iLogger = logger;
    }
    public void Save()
    {
        _iLogger.Log("user data in product manager and dependecy injection");
        Console.WriteLine("Saved");

    }
}
public interface ILogger
{
    void Log(string message);
}
public class EdLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine("Logged, {0}", message);
    }
}
public class Log4Net
{
    public void LogMessage(string message) {
        Console.WriteLine("Logged with log4net and message {0}",message);
    }
}
public class Log4NetAdapter : ILogger
{
    public void Log(string message)
    {
        Log4Net log4Net = new Log4Net();
        log4Net.LogMessage(message);
    }
}