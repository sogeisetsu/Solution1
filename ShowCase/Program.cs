using System;
namespace ShowCase
{

    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //new LibraryOne().One("你好");
            //new Class1();
            //FormatOne.Format();
            //new ClassCd();
            object c = "123";
            new AsIs().One(c);
            object cc = null;
            Console.WriteLine(cc == null ? "null" : cc.GetType());
            Console.WriteLine("按下任何键去停止并退出程序");
            Console.ReadKey(true);


        }
    }
}
