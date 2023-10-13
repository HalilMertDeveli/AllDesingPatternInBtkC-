using System;
namespace NullObjectDesing
{
    public class Program
    {
        public static void Main()
        {
            CustomerManager customerManager = new CustomerManager(new NLogLogger());
            customerManager.Save();

            Console.ReadLine();
        }
    }
}
public class CustomerManager
{
    ILogger _logger;

    public CustomerManager(ILogger logger)
    {
        this._logger = logger;
    }
    public void Save()
    {
        Console.WriteLine("Saved with Customer Manager");
        _logger.Log();
    }

}
public interface ILogger
{
    void Log();
}
public class Log4NetLogger : ILogger
{
    public void Log()
    {
        Console.WriteLine("Logged for log4Net");
    }
}
public class NLogLogger : ILogger
{
    public void Log()
    {
        Console.WriteLine("Looged for NLogger");
    }
}
public class StubLogger : ILogger
{
    private static StubLogger _stubLogger;

    private StubLogger()
    {
        
    }

    public static StubLogger CreateSingleton()
    {
        if(_stubLogger == null)
        {
            _stubLogger = new StubLogger();
        }
        return _stubLogger;
    }
    public void Log()
    {
        Console.WriteLine("Stublogger  doesn't do anything");
    }
}
public class CustomerManagerTest
{
    public void Saveest()
    {
        //CustomerManager customerManager = new CustomerManager();//it wants to Logger 
        CustomerManager customerManager = new CustomerManager(StubLogger.CreateSingleton());
        customerManager.Save();
    }
}