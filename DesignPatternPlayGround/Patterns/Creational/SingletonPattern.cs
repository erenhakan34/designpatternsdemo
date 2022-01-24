using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPlayGround.Patterns
{
    public static class SingletonPattern
    {
        public static void Run()
        {
            Console.WriteLine("Singleton Pattern\n-----------------");

            SingletonClass instance1 = SingletonClass.Instance;
            SingletonClass instance2 = SingletonClass.Instance;

            instance2.Prop1 = "Test";

            Console.WriteLine(instance1.Prop1);
            Console.WriteLine(instance2.Prop1);
            Console.WriteLine($"== > { instance1 == instance2}");
            Console.WriteLine($"Equals result > { instance1.Equals(instance2)}");
            Console.WriteLine($"ReferenceEquals result > { ReferenceEquals(instance1, instance2)}");
        }
    }


    public class SingletonClass
    {
        private SingletonClass() { }

        public string Prop1 { get; set; }

        private static SingletonClass instance;

        public static SingletonClass Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonClass();
                }

                return instance;
            }
        }
    }
}
