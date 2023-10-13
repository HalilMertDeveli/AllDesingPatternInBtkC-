using System;

namespace AbstractFactory
{
    public class Class1
    {
        public static void Main()
        {
            ProductManager productManager = new ProductManager(new Factory1());//you could chose neither Factory1 nor Factory2
            ProductManager productManager1 = new ProductManager(new Factory2());

            productManager.GetAll();
            productManager1.GetAll();
            Console.ReadLine(); 
        }
    }

    public abstract class Logging//busines job
    {
        public abstract void Log(string message);
    }
    public class Log4NetLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("logged with Log4Net");
        }
    }
    public class NLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with NLogger");
        }
    }

    public abstract class Caching
    {
        public abstract void Cache(string data);
    }

    public class MemCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with memcache");
        }
    }
    public class RedisCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with Redis cache");
        }
    }

    public abstract class CrosCuttingConcersFactory
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();
    }

    public class Factory1 : CrosCuttingConcersFactory
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();
        }

        public override Logging CreateLogger()
        {
            return new NLogger();
        }
    }
    public class Factory2 : CrosCuttingConcersFactory
    {
        public override Caching CreateCaching()
        {
            return new MemCache();
        }

        public override Logging CreateLogger()
        {
            return new Log4NetLogger();
        }
    }
    public class ProductManager : IProductService
    {
        CrosCuttingConcersFactory _crosCuttingConcersFactory;


        Logging _logging;
        Caching _caching;
        public ProductManager(CrosCuttingConcersFactory crosCuttingConcersFactory)
        {
            _crosCuttingConcersFactory = crosCuttingConcersFactory;
            _logging = crosCuttingConcersFactory.CreateLogger();
            _caching = crosCuttingConcersFactory.CreateCaching();
        }

        public void GetAll()
        {
            _logging.Log("logged");
            _caching.Cache("cached");
            Console.WriteLine("Product listed");
        }
    }
    public interface IProductService
    {
        void GetAll();
    }

}