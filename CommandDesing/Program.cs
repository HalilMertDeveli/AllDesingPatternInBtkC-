using System;

namespace CommandDesing
{
    public class Program
    {
        public static void Main()
        {
            StockManager stockManager = new StockManager();
            BuyStock buyStock = new BuyStock(stockManager);
            SellStock sellStock = new SellStock(stockManager);

            StockController stockController = new StockController();

            stockController.TakeOrder(buyStock);
            stockController.TakeOrder(sellStock);
            stockController.TakeOrder(buyStock);

            stockController.PlaceOrders();


            Console.ReadLine();
        }
    }
}
public class StockManager
{
    private string _name = "Laptop";
    private int quantity = 10;

    public void Buy()
    {
        Console.WriteLine("Stock :  {0},{1} bought", _name, quantity);
    }
    public void Sell()
    {
        Console.WriteLine("Stock :  {0},{1} sold", _name, quantity);

    }
}
public interface IOrder
{
    void Excute();
}
public class BuyStock : IOrder
{
    private StockManager _stockManager;

    public BuyStock(StockManager stockManager)
    {
        this._stockManager = stockManager;
    }

    public void Excute()
    {
        _stockManager.Buy();
    }
}
public class SellStock : IOrder
{
    private StockManager _stockManager;

    public SellStock(StockManager stockManager)
    {
        this._stockManager = stockManager;
    }
    public void Excute()
    {
        _stockManager.Sell();
    }
}
public class StockController
{
    List<IOrder> _orders = new List<IOrder>();

    public void TakeOrder(IOrder iorder)
    {
        _orders.Add(iorder);
    }
    public void PlaceOrders()
    {
        foreach (var order in _orders)
        {
            order.Excute();
        }
        _orders.Clear();
    }
}