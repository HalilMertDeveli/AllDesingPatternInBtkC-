using System;

namespace DecaratorDesignPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var personelCar = new PersonelCar { Make = "Opel", Model = 2001, HirePrice = 2500 };

            SpecialOffer specialOffer = new SpecialOffer(personelCar);
            specialOffer.DiscountPercentage = 10;

            Console.WriteLine("Special offer: {0}",specialOffer.HirePrice);
            Console.WriteLine("Personal offer: {0}",personelCar .HirePrice);
            Console.ReadLine();
        }
    }
}
abstract public class CarBase
{
    public abstract string Make { get; set; }
    public abstract int Model { get; set; }
    public abstract decimal HirePrice { get; set; }

}
public class PersonelCar : CarBase
{
    public override string Make { get ; set ; }
    public override int Model { get; set ; }
    public override decimal HirePrice { get ; set ; }
}
public class CommercialCar : CarBase
{
    public override string Make { get; set; }
    public override int Model { get; set; }
    public override decimal HirePrice { get; set; }
}
public abstract class CarDecaratorBase : CarBase
{
    private CarBase _carBase;

    protected CarDecaratorBase(CarBase carBase)
    {
        _carBase = carBase;
    }
}
public class SpecialOffer : CarDecaratorBase
{
    public int DiscountPercentage { get; set; }
    private CarBase _carBase;
    public SpecialOffer(CarBase carBase) : base(carBase)
    {
        this._carBase = carBase;
    }

    public override string Make { get; set; }
    public override int Model { get; set; }
    public override decimal HirePrice { get { return _carBase.HirePrice- _carBase.HirePrice *DiscountPercentage /100; } set { } }
}
