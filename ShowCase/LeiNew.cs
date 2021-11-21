using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HEIE
{
    public delegate void WTuo();

    internal class BookA
    {
        private string _author;

        private string _outCompany;

        public BookA()
        {
        }

        /// <summary>
        /// 定义书的基本信息
        /// </summary>
        /// <param name="name"> 书名 </param>
        /// <param name="peices"> 价格 </param>
        /// <param name="outCompany"> 出版商 </param>
        public BookA(string name, int peices, string outCompany = "无")
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Peices = peices;
            OutCompany = outCompany ?? throw new ArgumentNullException(nameof(outCompany));
        }

        /// <summary>
        /// 作者
        /// </summary>
        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        /// <summary>
        /// 书的出版商
        /// </summary>
        public string OutCompany { get => _outCompany; set => _outCompany = value; }

        /// <summary>
        /// 书的名称
        /// </summary>
        protected string Name { get; set; } = "《书名》";

        /// <summary>
        /// 书的价格
        /// </summary>
        protected int Peices { get; init; } = 0;

        /// <summary>
        /// 析构函数（终结器）
        /// </summary>
        ~BookA()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().DeclaringType.FullName);
            Console.WriteLine("终结器\t在整个程序结束的时候运行");
        }

        /// <summary>
        /// overload
        /// </summary>
        /// <returns></returns>
        protected internal string One()
        {
            return "验证function overload";
        }

        protected internal string One(int a)
        {
            Console.WriteLine("方法重载");
            string aString = a.ToString();
            return aString;
        }

        protected internal void One(string str)
        {
            Console.WriteLine(str);
        }
    }

    /// <summary>
    /// 常规意义上为实例化对象准备方法
    /// </summary>
    internal class DefaultFun
    {
        internal string Name { get; set; }
        /// <summary>
        /// 可以由实例化对象调用的方法
        /// </summary>
        /// <param name="name">准备的新的属性Name的值</param>
        internal void ChangeName(String name)
        {
            if (name.Length >= 3)
            {
                this.Name = name;
            }
        }
    }

    /// <summary>
    /// 为string类型增加拓展方法
    /// </summary>
    internal static class stringExtensions
    {
        /// <summary>
        /// demo，试图获取string实例化对象长度的两倍
        /// </summary>
        /// <param name="str">此方法的第一个参数指定方法所操作的类型；此参数前面必须加上 this 修饰符。</param>
        /// <returns>原来长度的两倍</returns>
        internal static int GetTheDoubleLength(this string str)
        {
            return str.Length * 2;
        }

        internal static ArrayList GetArrayList(this string str, int a)
        {
            string[] strings = new string[str.Length + 1];
            for (int i = 0; i < str.Length; i++)
            {

                strings[i] = str.Substring(i, 1);
            }
            strings[str.Length] = a.ToString();
            ArrayList arrayList = new(strings);
            return arrayList;
        }
    }

    internal class TestA
    {
        /// <summary>
        /// 混合使用构造器和初始化器
        /// </summary>
        internal void One()
        {
            // TODO 混合使用构造器和初始化器
            BookA book = new BookA("《123》", 12)
            {
                Author = "ASir"
            };

            Console.WriteLine(book);
        }

        /// <summary>
        /// 常规方法实例化对象和调用方法
        /// </summary>
        internal void Two()
        {
            //实例化对象
            DefaultFun defaultFun = new DefaultFun();
            //调用实例化对象的方法
            defaultFun.ChangeName("新的Name");
        }

        /// <summary>
        /// 调用无参拓展方法
        /// </summary>
        internal void Three()
        {
            var str = "1234";
            //在使用的时候直接调用就行，直接在实例化对象后面接方法名就行，不用带拓展方法所属于的静态类名
            int v = str.GetTheDoubleLength();
            Console.WriteLine(v);
        }

        /// <summary>
        /// 调用有参拓展方法
        /// </summary>
        internal void Four()
        {
            var str = "你好世界";
            ArrayList arrayList = str.GetArrayList(12);
            foreach (var item in arrayList)
            {
                Console.WriteLine($"{item.GetType()}\t{item}");
            }
        }
    }
}