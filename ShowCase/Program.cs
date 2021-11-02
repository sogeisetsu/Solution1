using System;

namespace ShowCase
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //new LibraryOne().One("你好");
            //new Class1();
            //FormatOne.Format();
            //new ClassCd();
            object c = "123";
            new AsIs().One(c);
            new AsIs().Two();
            try
            {
                object cc = null;
                Console.WriteLine(cc ?? throw new ArgumentNullException(nameof(cc)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            new AsIs().RefOut();
            new Operator().QuesttionMode();
            Console.WriteLine(new Operator().dd);
            Console.WriteLine("按下任何键去停止并退出程序");
            Console.ReadKey(true);
        }
    }
}