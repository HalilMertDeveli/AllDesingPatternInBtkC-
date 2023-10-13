using Microsoft.Extensions.Logging;

namespace Factory
{
    class Program
    {
        static void Main()
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactory2());
            CustomerManager customerManager1 = new CustomerManager(new LoggerFactory());
            customerManager.Save();

            Console.WriteLine("After customer manager \n");
            Console.ReadLine();
        }
    }
    
    public interface ILogger
    {
        void Log();
    }
   
    public class EdLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with EDLogger");
        }
    }
    public class EdLogger2 : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with EDLogger2");
        }
    }
    public class LoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()//factory is here 
        {
            //create business in here 
            return new EdLogger();
        }
    }
    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()//factory is here 
        {
            //create business in here 
            return new EdLogger2();
        }
    }
    public interface ILoggerFactory
    {
        public ILogger CreateLogger();
    }


    public class CustomerManager
    {
        private ILoggerFactory _loggerFactory;
        public CustomerManager(ILoggerFactory loggerFactory)
        {
            this._loggerFactory = loggerFactory;
        }
        public void Save()
        {
            Console.WriteLine("Saved on Customer manager");
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log(); 
        }
    }
}