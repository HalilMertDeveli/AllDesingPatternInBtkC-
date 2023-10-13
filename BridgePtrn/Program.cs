using System;
namespace BridgePtrn
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.MessageSenderBase = new EmailSender();
            //customerManager.MessageSenderBase = new SmsSender();

            customerManager.UpdateCustomer();
            



            
            Console.ReadLine();
        }
    }
}
public abstract class MessageSenderBase
{
    public void SaveSentMessageToDatabase()
    {
        Console.WriteLine("sent message has been saved our database");
    }
    public abstract void Send( Body body);
  
}
public class Body
{
    public string Title { get; set; }
    public string Text { get; set; }
    
}
public class SmsSender : MessageSenderBase
{
    public override void Send(Body body)
    {
        Console.WriteLine("{0} was sent via SmsSender", body.Title);
    }
}
public class EmailSender : MessageSenderBase
{
    public override void Send(Body body)
    {
        Console.WriteLine("{0} was sent via Email Sender", body.Title);
    }
}
public class CustomerManager
{
    public MessageSenderBase MessageSenderBase { get; set; }
    public void UpdateCustomer()
    {
        MessageSenderBase.Send(new Body { Title="body Title",Text="body text"});
        Console.WriteLine("Customer Updated");
    }
}