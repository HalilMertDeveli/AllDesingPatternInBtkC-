using System;
namespace StrategyDesignPtrn
{
    public class Program
    {
        public static void Main()
        {
            //choose what will you use 
            CustomerManager customerManager = new CustomerManager();
            customerManager.caculateCreditBase = new After2023CreditCalculater();
            customerManager.SaveCredit();


            //choose what will you use
            CustomerManager customerManager2 = new CustomerManager();
            customerManager2.caculateCreditBase = new Before2023CreditCalculater();
            customerManager2.SaveCredit();





            Console.ReadLine();
        }
    }
}
public abstract class CaculateCreditBase
{
    public abstract void Calculate();
}
public class Before2023CreditCalculater : CaculateCreditBase
{
    public override void Calculate()
    {
        Console.WriteLine("Calculated Credit before2023");
    }
}
public class After2023CreditCalculater : CaculateCreditBase
{
    public override void Calculate()
    {
        Console.WriteLine("Calculated Credit After2023");
    }
}
public class CustomerManager
{
    public CaculateCreditBase caculateCreditBase { get; set; }

    public void SaveCredit()
    {
        Console.WriteLine("Customer manager business");
        caculateCreditBase.Calculate();
    }
}