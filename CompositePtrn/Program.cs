using System;
using System.Collections;

namespace CompositePtrn
{
    public class Program
    {
        public static void Main()
        {
            Employee halil = new Employee { Name="Halil"};


            Employee furkan = new Employee { Name="Furkan"};

            Employee yusuf = new Employee { Name="Yusuf"};
            halil.AddSuboridante(furkan);
            halil.AddSuboridante(yusuf);

            Employee ahmet = new Employee { Name="Ahmet"};
            yusuf.AddSuboridante(ahmet);

            Contractor ali = new Contractor { Name="Ibrahim"};

            ahmet.AddSuboridante(ali);

            foreach(IPerson managerElements in ahmet)
            {
                Console.WriteLine(managerElements.Name);
            }
            

            foreach(Employee manager in halil)
            {
                Console.WriteLine(manager.Name);
                
              
                
            }
            Console.WriteLine("-------");
            foreach (Employee subordinateManager in yusuf)
            {
                Console.WriteLine(subordinateManager.Name);
            }


            Console.ReadLine();
        }
    }
}
public interface IPerson
{
    string Name { get; set; }
}
public class Contractor : IPerson
{
    public string Name { get; set; }
}
public class Employee : IPerson,IEnumerable<IPerson>
{
    List<IPerson> _subordinates = new List<IPerson>();
    public string Name { get; set; }

    public void AddSuboridante(IPerson iperson)
    {
        _subordinates.Add(iperson);
    }
    public void RemoveSubordinate(IPerson iperson)
    {
        _subordinates.Remove(iperson);
    }
    public IPerson GetSubordinate(int index)
    {
        return _subordinates[index];
    }

    public IEnumerator<IPerson> GetEnumerator()
    {
        foreach (var subordinate in _subordinates)
        {
            yield return subordinate;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}


