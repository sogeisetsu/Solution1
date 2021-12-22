using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            foreach (var item in args)
            {
                Console.WriteLine(item);
            }

            Test test = new Test();
            test.Three();
            Console.WriteLine("==-=-=four-=-=-=-=-");
            test.Four();
        }
    }
}
