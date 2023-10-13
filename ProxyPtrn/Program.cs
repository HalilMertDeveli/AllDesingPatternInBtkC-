using System;

namespace ProxyPtrn
{
    public class Program
    {
        public static void Main()
        {
            CreditBase creditManager = new CreditManagerProxy();

            Console.WriteLine(creditManager.CaculateCredit());
            Console.WriteLine(creditManager.CaculateCredit());


            Console.WriteLine("Hello world");
            Console.ReadLine();
        }
    }
}
public abstract class CreditBase
{
    public abstract int CaculateCredit();
}

public class CreditManager : CreditBase
{
    public override int CaculateCredit()
    {
        int result = 1;
        for(int i = 1; i <= 5; i++)
        {
            result *= i;
            Thread.Sleep(1000);
        }
        return result;
    }
}
public class CreditManagerProxy : CreditBase
{
    private CreditManager _creditManager;
    private int _cachedValue;

    public override int CaculateCredit()
    {
        if(_creditManager == null)
        {
            _creditManager = new CreditManager();
            _cachedValue = _creditManager.CaculateCredit();
        }
        return _cachedValue;
    }
}