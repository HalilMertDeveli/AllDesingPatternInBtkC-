using System;

namespace FacedDesign
{
    public class Program
    {
        public static void Main()
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();


            Console.ReadLine();
        }
    }
}
public class Logging:ILogging
{
    public void Log()
    {
        Console.WriteLine("logged");
    }
}
public interface ILogging
{
    void Log();
}
public class Caching:ICaching
{
    public void Cache()
    {
        Console.WriteLine("Cached");
    }
}
public interface ICaching
{
    void Cache();
}
public class Authorize:IAuthorize
{
    public void CheckUser()
    {
        Console.WriteLine("User checked");
    }
}
public interface IAuthorize
{
    void CheckUser();
}
public class CustomerManager
{

    private CrossCuttingConcersFacade concers;

    public CustomerManager()
    {
        concers = new CrossCuttingConcersFacade();
    }
    public void Save()
    {
        concers.ICaching.Cache();
        concers.ILogging.Log();
        concers.IAutohorize.CheckUser();
        Console.WriteLine("Save");
        
    }
  
}
public class CrossCuttingConcersFacade
{
    public ILogging ILogging;
    public ICaching ICaching;
    public IAuthorize IAutohorize;

    public CrossCuttingConcersFacade()
    {
        ILogging = new Logging();
        ICaching = new Caching();
        IAutohorize = new Authorize();
    }


}
