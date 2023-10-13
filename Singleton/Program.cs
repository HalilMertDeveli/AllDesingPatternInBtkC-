namespace Signleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Helo world");
            //CustomerManager customerManager = new CustomerManager();
            var singletonObject = CustomerManager.CreateAsSingleton();
            singletonObject.Save();

        }
    }
}
class CustomerManager
{
    private static CustomerManager _customerManager;
    static object _lockObject = new object();
    private CustomerManager()
    {

    }
    public static CustomerManager CreateAsSingleton()
    {
        lock (_lockObject)
        {
            if (_customerManager == null)
            {
                _customerManager = new CustomerManager();
            }
        }



        return _customerManager;
    }

    public void Save()
    {
        Console.WriteLine("All things have been saved ");
    }
}
