using System;

namespace ProtottypePattern
{
    public class Program
    {
        public static void Main()
        {
            Customer customer = new Customer { Id = 1, FirstName = "Halil Mert", LastName = "Develi", City = "Yozgat" };

            Customer customer1 = (Customer) customer.Clone();
            customer1.FirstName = "Musa";

            Console.WriteLine(customer.FirstName);
            Console.WriteLine(customer1.FirstName);


       
        }
    }
    public abstract class Person
    {
        public abstract Person Clone();//you need to create a clone metod 
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Customer : Person
    {
        public string City { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
    public class Employee : Person
    {
        public byte Salary { get; set; }
        public override Person Clone()
        {
            throw new NotImplementedException();
        }
    }
}