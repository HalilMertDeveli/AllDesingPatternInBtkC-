using System;
namespace ChainOfResponsibility
{
    public class Program
    {
        public static void Main()
        {

            Manager manager = new Manager();
            VicePresident vicePresident = new VicePresident();
            President president = new President();

            manager.SetSuccesor(vicePresident);
            vicePresident.SetSuccesor(president);

            Expense expense = new Expense { Amount = 9000, Detail = "Education" };
            manager.HandleExpense(expense);//buraya tek bir expense veriyorsun o da gerekli yerlere kodlar ile gidiyor

            Console.ReadLine();
        }
    }
}
public class Expense
{
    public string Detail { get; set; }
    public decimal  Amount { get; set; }
}
public abstract class ExpenseHandlerBase
{
    protected ExpenseHandlerBase Successor;
    public abstract void HandleExpense(Expense expense);

    public void SetSuccesor(ExpenseHandlerBase successor)
    {
        Successor = successor;
    }
}
public class Manager : ExpenseHandlerBase
{
    public override void HandleExpense(Expense expense)
    {
        if (expense.Amount<100)
        {
            Console.WriteLine("bought that ");
        }
        else if (Successor != null)
        {
            Successor.HandleExpense(expense);
        }
    }
}
public class VicePresident : ExpenseHandlerBase
{
    public override void HandleExpense(Expense expense)
    {
        if (expense.Amount > 100 && expense.Amount <1000)
        {
            Console.WriteLine("Vice President handled expensed  ");
        }
        else if (Successor != null)
        {
            Successor.HandleExpense(expense);
        }
    }
}
public class President : ExpenseHandlerBase
{
    public override void HandleExpense(Expense expense)
    {
        if (expense.Amount > 1000 && expense.Amount < 10000)
        {
            Console.WriteLine(" President handled expensed  ");
        }
        else if (Successor != null)
        {
            Console.WriteLine("expense is not handled");
        }
    }
}