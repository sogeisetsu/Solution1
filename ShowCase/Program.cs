using HEIE;
using System;
using System.Reflection;

namespace ShowCase
{
    internal class Program
    {
        private Action cc;

        /// <summary>
        /// 委托，此委托可以封装任何没有参数，返回值是string的函数
        /// </summary>
        /// <returns> 返回值，被委托的函数应该返回字符串 </returns>
        public delegate string GetMethodName();

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

            //Console.WriteLine("不想被破解");
            ////new DY().two();
            //Operator.RefOut refOut = new Operator.RefOut();
            //refOut.TestDiff();
            //Console.WriteLine("---------------------------------");
            //// 委托封装函数
            //GetMethodName name = MethodBase.GetCurrentMethod().DeclaringType.ToString;
            //Console.WriteLine(nameof(name) + "\t" + name.GetType());
            //name();
            //new Hello();

            //DY dY = new DY();
            //dY.Three();
            //Operator.LambdaTest lambdaTest = new Operator.LambdaTest();
            //lambdaTest.Test();
            #endregion

            TestA testA = new TestA();
            testA.One();
            //testA.Two();
            //testA.Three();
            //testA.Four();
            //testA.Five();
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-");
            //testA.SixDifference();
            testA.Seven();
            Console.WriteLine("按下任何键去停止并退出程序");
            Console.ReadKey(true);
        }
    }
}