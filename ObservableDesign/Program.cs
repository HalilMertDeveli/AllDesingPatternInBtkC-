using System;
namespace ObservableDesign
{
    public class Program
    {
        public static void Main()
        {

            ProductManager productManagerInstance = new ProductManager();

            CustomerObserver customerObserverInstance = new CustomerObserver();
            EmployeeObserver employeeObserverInstance = new EmployeeObserver();

            productManagerInstance.Attach(customerObserverInstance);//adding subscirption
            productManagerInstance.Attach(employeeObserverInstance);

            

            productManagerInstance.Attach(customerObserverInstance);//adding subscirption
            productManagerInstance.Attach(employeeObserverInstance);
            productManagerInstance.Detach(customerObserverInstance);
            

            productManagerInstance.UpdatePrice();
            Console.ReadLine();
        }
    }
}
public class ProductManager
{
    List<Observer> _observerList = new List<Observer>();
    public void UpdatePrice()
    {
        Console.WriteLine("Product price has been updated");
        Notify();
    }
    //Adding subscription
    public void Attach(Observer observer)
    {
        _observerList.Add(observer);
    }
    //delete subscription
    public void Detach(Observer observer)
    {
        _observerList.Remove(observer);
    }
    //give info to subscription
    public void Notify()
    {
        foreach(var observers in _observerList)
        {
            observers.Update();
        }
    }

}
public abstract class Observer
{
    public abstract void Update();
}
public class CustomerObserver:Observer
{
    public override void Update()
    {
        Console.WriteLine("Message to customer:  Product price changed");
    }
}
public class EmployeeObserver : Observer
{
    public override void Update()
    {
        Console.WriteLine("Message to Employee: Product price changed");
    }
}