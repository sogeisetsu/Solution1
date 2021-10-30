using ClassLibrary1;
using System;
using Format;
namespace ShowCase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            new LibraryOne().One("你好");
            Console.WriteLine("按下任何键去停止并退出程序");
            Console.ReadKey(true);
            FormatOne.Format();
        }
    }
}
