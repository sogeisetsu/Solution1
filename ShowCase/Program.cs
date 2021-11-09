using System;
using System.Reflection;
namespace ShowCase
{
    internal class Program
    {
        internal static void WeiT()
        {
            Console.WriteLine("hello 委托");
            Console.WriteLine(MethodBase.GetCurrentMethod().DeclaringType.FullName + MethodBase.GetCurrentMethod().ToString());
        }
        private static void Main(string[] args)
        {
            #region 
            //Console.WriteLine("Hello World!");
            //new LibraryOne().One("你好");
            //new Class1();
            //FormatOne.Format();
            //new ClassCd();
            //object c = "123";
            //new AsIs().One(c);
            //new AsIs().Two();
            //try
            //{
            //    object cc = null;
            //    Console.WriteLine(cc ?? throw new ArgumentNullException(nameof(cc)));
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //}
            //new AsIs().RefOut();
            //new Operator().QuesttionMode();
            //Operator @operator = new Operator();
            //@operator.IsAs();
            //Console.WriteLine(new Operator().dd);
            //int? cc = null;
            //Console.WriteLine(cc == null ? "null" : cc);
            //Console.WriteLine("+++++++++++++++++++++++++");
            //new PropertyTry().ReClass();

            //new Testt();

            //Action action = new Action(WeiT);
            //Action<string> action1 = new Action<string>(new Testt().WeiT);
            //action();
            //action1("你好，非静态委托");
            #endregion

            new DY().two();

            Console.WriteLine("按下任何键去停止并退出程序");
            Console.ReadKey(true);
        }
    }
}