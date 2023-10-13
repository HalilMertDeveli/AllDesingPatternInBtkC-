using Ninject;
using System;
namespace Visitor
{
    public class Program
    {
        public static void Main()
        {
            IKernel karnel = new StandardKernel();
            karnel.Bind<IProductDal>().To<ProductDal>().InSingletonScope();


            ProductManager productManager = new ProductManager(karnel.Get<IProductDal>());
            productManager.Save();

            Console.ReadLine();
            
        }
    }
}
public interface IProductDal
{
    void Save();
}
public class ProductDal:IProductDal
{
    public void Save()
    {
        Console.WriteLine("Saved in product dal");
    }

}
public class ProductManager
{
    IProductDal _iProductDal;
    public ProductManager(IProductDal iProductDal)
    {
        _iProductDal = iProductDal;
    }

    public void Save()
    {
        _iProductDal.Save();
    }
}