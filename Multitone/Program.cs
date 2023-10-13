using System;
namespace Multitone
{
    public class Program
    {
        public static void Main()
        {
            Camera camera1 = new Camera.GetCamera("NIKON");
            Camera camera2 = new Camera.GetCamera("NIKON");

            Camera camera3 = new Camera.GetCamera("CONON");

            Camera camera4 = new Camera.GetCamera("CONON");

            Console.WriteLine(camera1.Id);
            Console.WriteLine(camera2.Id);
            Console.WriteLine(camera3.Id);
            Console.WriteLine(camera4.Id);

            Console.ReadLine();
        }
    }

}
public class Camera
{
    static Dictionary<string, Camera> _cameras = new Dictionary<string, Camera>();
    static object _lock = new object();
    public Guid Id { get; set; }

    private Camera()
    {
        Id = Guid.NewGuid();
    }
    public static Camera GetCamera(string brand)
    {
        lock(_lock)
        {
            if (!(_cameras.ContainsKey(brand)))
            {
                _cameras.Add(brand, new Camera());
            }
        }
        return _cameras[brand];
    }

}